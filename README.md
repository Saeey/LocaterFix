# Locater Fix · Locater 修复补丁

官方 [Hyru-Locater 1.3.5](https://thunderstore.io/c/riskofrain2/p/Hyru/Locater/) 的非官方独立补丁。修复静态标记的空引用报错，并新增未修理无人机购买点标记。需要同时安装并启用原版 Locater。

Unofficial companion for [Hyru-Locater 1.3.5](https://thunderstore.io/c/riskofrain2/p/Hyru/Locater/). Fixes static-marker null-reference errors and adds markers for unrepaired drone purchase points. The original Locater must remain installed and enabled.

## 1.1.0 功能 / Features

- 未修理且可购买的无人机显示青色无人机图标；已修理的跟随无人机不标记。
- 修理、对象销毁、换关或关闭功能后清理标记，沿用 Locater 的大小、定位设置和 Ctrl+H 显示开关。
- 保留此前的静态标记修复：停用不适用于静态标记的充能更新组件，保留颜色，隐藏不使用的文字。
- 移除原版遗留的测试箱子场景钩子，仅处理 Locater 自己的指定方法。

- Available, unrepaired drone purchase points receive a cyan drone icon. Repaired followers are excluded.
- Markers are cleaned up after repair, destruction, stage change or feature disable; Locater scale, positioning and Ctrl+H visibility controls are reused.
- Retains the static-marker fix: disables the unsuitable charge updater, preserves colors and hides unused text.
- Removes Locater's exact leftover test-chest scene postfix, targeting only Locater's specified methods.

这是本地视觉功能，不改变价格、购买结果、生成表或网络消息。原生传送器指示器与其他模组的场景钩子不受本补丁拦截。

This is a local visual feature. It does not change prices, purchases, spawn tables or network messages. Native teleporter indicators and other mods' scene hooks are not intercepted.

## 安装与配置 / Installation and configuration

1. 在 r2modman 或 Thunderstore Mod Manager 安装或更新 **for_null-Locater_Fix 1.1.0**，允许安装依赖。
2. 同时启用官方 **Hyru-Locater 1.3.5** 与本补丁，完全退出并重启游戏。
3. 手动安装：安装依赖后，将 `plugins/LocaterFix.dll` 放入 `BepInEx/plugins`，避免重复 DLL。

Install or update **for_null-Locater_Fix 1.1.0** with r2modman or Thunderstore Mod Manager, allow dependencies, and keep **Hyru-Locater 1.3.5** enabled. Fully restart the game. For manual installation, install dependencies and put `plugins/LocaterFix.dll` in `BepInEx/plugins`; avoid duplicate DLLs.

配置文件 / Configuration: `BepInEx/config/for_null.locaterfix.cfg`

```ini
[Drone markers]
Show unrepaired drones = true
Marker color = 40E6FFFF
```

`Show unrepaired drones` 控制是否显示无人机购买点，`Marker color` 控制颜色。原 Locater 的 Ctrl+H 同时控制这些标记。

`Show unrepaired drones` enables drone purchase-point markers; `Marker color` sets their color. Locater's Ctrl+H also controls these markers.

如使用过早期直接修改原 DLL 的私人测试版，请先重装官方 Locater。原包已有的 Deprecated 标签可能仍会显示。

If you used the earlier private binary modification, reinstall official Locater first. The original package may still show its existing Deprecated label.

## 兼容性与验证 / Compatibility and validation

仅支持官方 Locater 1.3.5 DLL，SHA-256 为 `795383f173adc9b9ac50ace3b426993105ef362fd3578e9a0a2bef3896d24599`；遇到其他 DLL 会记录日志并停止应用补丁。

Only the official Locater 1.3.5 DLL with SHA-256 `795383f173adc9b9ac50ace3b426993105ef362fd3578e9a0a2bef3896d24599` is supported. Other binaries are rejected with a log message.

1.1.0 已通过构建和 12 项无人机识别规则测试。在 Windows / RoR2 1.5.0#1224 的隔离配置中，实际观察到新版加载、正常出舱，以及本局 `JunkDroneBroken` 的青色标记；随后由用户确认游戏内功能正常并授权发布。快捷键与修理移除未由自动化独立完成验收。跨关卡、所有无人机变种、双人联机与长时间游玩未完成系统验证。

Version 1.1.0 builds successfully and passes 12 drone-classification cases. An isolated Windows / RoR2 1.5.0#1224 session directly confirmed loading, pod exit and the cyan marker for a naturally spawned `JunkDroneBroken`. The user subsequently confirmed in-game functionality and approved release. Automation did not independently complete shortcut and repair-removal checks. Stage transitions, every drone variant, two-player sessions and long sessions have not received systematic validation.

其他模组错误不在本补丁范围内。详见 `VALIDATION.md`。

Errors from other mods are outside this patch's scope. See `VALIDATION.md` for the precise validation record.

## 源码、致谢与许可证 / Source, credits and license

- [GitHub 源码与标准 dotnet 工程 / Source and standard dotnet project](https://github.com/Saeey/LocaterFix)
- 原版作者 / Original Locater: **Hyru / Hyrulien**。
- 补丁发布 / Companion publisher: **for_null**。开发使用 AI 辅助，已标注 AI Generated / Developed with AI assistance and tagged AI Generated.
- MIT 许可证仅覆盖本补丁。原版 Locater 的代码、素材和许可归原作者 / MIT covers this companion only; original Locater code, assets and licensing remain with its author.
- 安装包只含补丁 DLL、用户文档、许可证和新图标；源码、构建文件与测试放在仓库，不分发原模组或游戏 DLL / The installation ZIP contains only the companion DLL, player documentation, license and a new icon. Source, build files and tests live in the repository; original mod and game DLLs are excluded.

## 构建与打包 / Build and package

需要 .NET 8 SDK 和自行安装的游戏/BepInEx 引用。将 `Local.Paths.props.example` 复制为 `Local.Paths.props`，填写两个引用目录，再执行：

Install the .NET 8 SDK and supply references from your own game/BepInEx installation. Copy `Local.Paths.props.example` to `Local.Paths.props`, fill in both reference directories, then run:

```console
dotnet build src/LocaterFix/LocaterFix.csproj -c Release
dotnet run --project tests/DroneTargets/DroneTargets.csproj -c Release
```

产物 / Output: `src/LocaterFix/bin/Release/netstandard2.1/LocaterFix.dll`。

新构建的 DLL 需自行游戏实测后再发布。标准工程通过显式清单打包，不复制第三方引用、源码、日志或机器路径：

Test any newly built DLL in-game before publishing it. The package target uses an explicit allowlist and excludes third-party references, source, logs and machine paths:

```console
dotnet build src/LocaterFix/LocaterFix.csproj -c Release -t:PackageRelease
```

`src/LocaterFix` 保存插件源码，`tests/DroneTargets` 保存纯识别规则测试，`thunderstore` 保存玩家文档与元数据。1.1.0 使用新构建的运行 DLL；历史 1.0.1 是沿用 1.0.0 DLL 的纯打包更新。

`src/LocaterFix` contains the plugin source, `tests/DroneTargets` the pure classification tests, and `thunderstore` player documentation and metadata. Version 1.1.0 ships a newly built runtime DLL; historical 1.0.1 was a packaging-only revision reusing the 1.0.0 DLL.
