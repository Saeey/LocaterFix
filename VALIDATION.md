# Release validation

## Package 1.0.1

This is a packaging-only revision of 1.0.0. The shipped plugin DLL is byte-for-byte identical to the DLL tested below (SHA-256 `1232dc4aa0d9c0faf3b3fe67e4fef01f9118621ad88752954c40e88d289b73e9`). Its BepInEx plugin version remains 1.0.0. No new gameplay test is claimed for this package revision.

The separate SDK-style .csproj builds successfully with the .NET 8 SDK using local game/BepInEx references. That rebuilt binary is not included in package 1.0.1 and has not itself received an in-game smoke test. Rebuilt binaries must be tested before a future runtime update.

## Original plugin test

Locater Fix 1.0.0 was tested on Windows on 2026-10-17 with Risk of Rain 2 build 1.5.0#1224, official Locater 1.3.5 and a cloned mod profile.

The original Locater DLL was restored before this test. This was a test of the standalone companion DLL included in this download, not the earlier private binary modification.

Observed in an actual single-player first-stage session lasting approximately 35 seconds:

- Both official Locater and Locater Fix loaded. The patch verified the expected original DLL hash and reported successful installation of both fixes.
- Locater reported 22 markers created; colored interactable markers were visible in-game.
- The player could leave the escape pod.
- Ctrl+H hid the Locater markers, and a second press showed them again. Other mods' teleporter markers remained visible.
- The session log contained zero `ChargeIndicatorController.Update` exceptions and zero leftover `TESTING` chest-spawn messages.

This was a short smoke test. Purchase-related marker removal, stage transitions, multiplayer and long sessions were not tested. Existing unrelated errors were still present in the modded profile (including HighItemVizability, a shader addressable, connection-ready and shutdown UI/pool messages). This package does not claim to fix those.

The original mod's verbose shrine diagnostic messages are also unchanged. A Harmony AccessTools warning about the absent private local-fix helper can appear during detection of an unmodified official DLL; it is followed by the explicit successful-initialization message.

Companion DLL SHA-256: `1232dc4aa0d9c0faf3b3fe67e4fef01f9118621ad88752954c40e88d289b73e9`.
