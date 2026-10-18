# 1.1.0 验证记录 / Validation record

Date / 日期: 2026-10-18 (Asia/Shanghai).

- 构建：.NET 8 SDK，引用已安装 RoR2 1.5.0#1224；0 警告、0 错误 / Build: .NET 8 SDK against installed RoR2 1.5.0#1224; zero warnings and errors.
- 自动化：12 项无人机识别规则测试通过，含正例与箱子、回收器、炮塔、跟随者名称、空元数据反例。这些不是 Unity 场景测试 / Automated: 12 classification cases passed, including drone positives and chest, scrapper, turret, live-body-name and null negatives. These are not Unity scene tests.
- 游戏实测：隔离配置中加载 Locater Fix 1.1.0，正常出舱；自然生成的 `JunkDroneBroken(Clone)` 位置显示青色无人机图标 / Direct gameplay observation: Locater Fix 1.1.0 loaded in an isolated profile, pod exit worked, and a cyan drone icon appeared at a naturally spawned `JunkDroneBroken(Clone)`.
- 用户验收：用户随后确认功能无问题，并明确授权发布。自动化操作中止后未独立完成 Ctrl+H 与修理移除验收，因此不将其描述为自动化通过 / User acceptance: the user subsequently confirmed functionality and explicitly approved publication. Automation was stopped before independently completing Ctrl+H and repair-removal checks; those are not claimed as automated passes.
- 未系统验证：跨关卡、每种无人机变体、双人联机、长时间游玩 / Not systematically tested: stage transitions, every drone variant, two-player sessions and long sessions.
- 本次日志另有 HighItemVizability 的 PickupDisplay.Start 空引用、shader addressable 和 connection-ready 错误，均不属于本补丁修复范围；不能声称整个模组环境无报错 / The profile also logged a HighItemVizability PickupDisplay.Start null reference, shader-addressable and connection-ready errors. This companion does not fix those or claim an error-free mod environment.

这是新的运行 DLL，不沿用 1.0.x 二进制 / This is a new runtime DLL, not the historical 1.0.x binary.

DLL SHA-256: `2359f956b9f590036b0b52ae68c6ef62574098323823d3df53f5d043ac56c920`.

Test command: `dotnet run --project tests/DroneTargets/DroneTargets.csproj -c Release`.

---

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
