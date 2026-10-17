using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using RoR2;
using RoR2.UI;
using UnityEngine;

namespace ForNull.LocaterFix
{
    [BepInPlugin("for_null.locaterfix", "Locater Fix", "1.0.0")]
    [BepInDependency("com.Hyru.Locater", BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Risk of Rain 2.exe")]
    public sealed class LocaterFixPlugin : BaseUnityPlugin
    {
        private const string OriginalSha256 = "795383F173ADC9B9AC50ACE3B426993105EF362FD3578E9A0A2BEF3896D24599";
        private Harmony harmony;

        private void Awake()
        {
            try
            {
                PluginInfo info;
                if (!Chainloader.PluginInfos.TryGetValue("com.Hyru.Locater", out info) || info.Instance == null)
                    throw new InvalidOperationException("Original Locater must be installed and enabled.");

                Type type = info.Instance.GetType();
                // Do not stack a runtime patch over the earlier private binary repair.
                if (AccessTools.DeclaredMethod(type, "PrepareStaticMarkerLocalFix") != null)
                {
                    Logger.LogWarning("Locater already contains the private local-fix1 binary repair. No runtime patch applied. Restore official Locater 1.3.5 when using this public plugin.");
                    return;
                }

                string hash;
                using (SHA256 sha = SHA256.Create())
                    hash = BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(type.Assembly.Location))).Replace("-", "");
                if (info.Metadata.Version != new Version(1, 3, 5) || hash != OriginalSha256)
                {
                    Logger.LogError("Unsupported Locater binary (" + info.Metadata.Version + ", SHA256 " + hash + "). This release only supports the official Hyru-Locater-1.3.5 package. Nothing was patched.");
                    return;
                }

                MethodInfo cleanup = AccessTools.DeclaredMethod(type, "RemoveEdgeComponents", new Type[] { typeof(GameObject) });
                MethodInfo testSpawn = AccessTools.DeclaredMethod(type, "OnPopulateScenePostfix", new Type[] { typeof(SceneDirector) });
                MethodInfo populate = AccessTools.DeclaredMethod(typeof(SceneDirector), "PopulateScene");
                MethodInfo prefix = AccessTools.DeclaredMethod(typeof(LocaterFixPlugin), "PrepareStaticMarker");
                if (cleanup == null || testSpawn == null || populate == null || prefix == null)
                    throw new MissingMethodException("Locater marker or scene methods could not be located.");

                Patches scenePatches = Harmony.GetPatchInfo(populate);
                if (scenePatches == null || !scenePatches.Postfixes.Any(p => p.PatchMethod == testSpawn))
                    throw new InvalidOperationException("Locater's expected test-spawn postfix was not registered. Refusing an unexpected setup.");

                harmony = new Harmony("for_null.locaterfix");
                harmony.Patch(cleanup, prefix: new HarmonyMethod(prefix));
                // Remove only this exact Locater postfix. Other mods' scene hooks remain.
                harmony.Unpatch(populate, testSpawn);
                scenePatches = Harmony.GetPatchInfo(populate);
                if (scenePatches != null && scenePatches.Postfixes.Any(p => p.PatchMethod == testSpawn))
                    throw new InvalidOperationException("Locater's test-spawn postfix could not be removed.");

                Logger.LogInfo("Locater Fix 1.0.0 enabled for official Locater 1.3.5: static marker cleanup prefix installed; leftover test chest spawns removed.");
            }
            catch (Exception exception)
            {
                if (harmony != null)
                    harmony.UnpatchSelf();
                Logger.LogError("Locater Fix did not initialize: " + exception);
            }
        }

        // Only called for Locater's own private marker-cleanup method. Native
        // teleporter indicators and other mods' indicators are not intercepted.
        private static void PrepareStaticMarker(GameObject indicator)
        {
            if (!indicator)
                return;
            ChargeIndicatorController charge = indicator.GetComponent<ChargeIndicatorController>();
            if (!charge)
                return;

            // Locater deletes some of the prefab's sprites. The teleporter
            // updater must stop before those cached references become invalid.
            charge.enabled = false;
            SpriteRenderer[] sprites = charge.iconSprites;
            if (sprites != null)
                foreach (SpriteRenderer sprite in sprites)
                    if (sprite)
                        sprite.color = charge.spriteBaseColor;

            if (charge.chargingText)
                charge.chargingText.gameObject.SetActive(false);
            if (charge.pingText)
                charge.pingText.gameObject.SetActive(false);
        }
    }
}
