# Locater Fix · Locater 修复补丁

官方原版 [Locater 1.3.5（Hyru）](https://thunderstore.io/c/riskofrain2/p/Hyru/Locater/) 的非官方独立补丁。需要同时安装并启用原版 Locater。

Unofficial, client-side companion patch for [Locater by Hyru](https://thunderstore.io/c/riskofrain2/p/Hyru/Locater/). The original Locater must remain installed and enabled.

## 修复功能 / Fixes

- 修复 Locater 标记持续触发 `ChargeIndicatorController.Update` 空引用报错的问题。
- 保留标记颜色，隐藏不使用的充能和 ping 文字。
- 移除原版遗留的测试箱子生成钩子。修复仅作用于 Locater 自己的指定方法，保留游戏原生传送器指示器和其他模组的场景钩子。

- Stops `ChargeIndicatorController.Update` null-reference spam caused by Locater removing parts of its indicator prefab while the charge updater keeps running.
- Preserves Locater marker colors and hides unused charge/ping text.
- Removes Locater's exact leftover scene-population test hook that tries to spawn test chests.

The patch targets Locater's own private marker cleanup and exact test postfix. Native teleporter indicators and other mods' scene hooks are not intercepted.

## 安装 / Installation

1. 在 r2modman 或 Thunderstore Mod Manager 安装 **Locater Fix**，允许安装依赖。
2. 同时启用官方原版 **Hyru-Locater 1.3.5** 和本补丁，然后重启游戏。
3. 手动安装时，将 `plugins/LocaterFix.dll` 放入 `BepInEx/plugins`。

如使用过早期直接修改 DLL 的私人测试版，请先重装官方原版 Locater，避免保留重复 DLL。原版已有的 Deprecated 标签可能仍会显示。

Install **Locater Fix** with r2modman or Thunderstore Mod Manager and allow its dependencies. Keep **Hyru-Locater 1.3.5** enabled, then restart the game.

Manual installation: install the dependencies, then place `plugins/LocaterFix.dll` in `BepInEx/plugins`.

If you used our earlier private binary repair, reinstall official Locater 1.3.5 first. Do not keep duplicate Locater DLLs. The original package may still show its existing Deprecated label.

## 适配范围与验证 / Compatibility and validation

仅支持官方 Locater 1.3.5 DLL。补丁会检查版本和下方文件哈希，遇到其他或更新后的 DLL 时记录日志并停止应用修复。

已在 Windows / RoR2 1.5.0#1224 的短时单人第一关实测：生成 22 个彩色标记，正常出舱，Ctrl+H 隐藏和恢复正常，本次日志中目标更新异常和 TESTING 箱子消息均为 0。购买后的标记移除、跨关卡、联机和长时间游玩尚未验证。其他模组错误不在修复范围内，详见 `VALIDATION.md`。

**1.0.1 仅调整打包与源码链接，沿用已实测的 1.0.0 DLL，因此 BepInEx 插件版本仍为 1.0.0。**

Only the official Locater 1.3.5 DLL is supported (SHA-256 `795383f173adc9b9ac50ace3b426993105ef362fd3578e9a0a2bef3896d24599`). Changed or updated binaries are rejected with a log message.

The standalone plugin was smoke-tested on Windows with RoR2 1.5.0#1224: 22 colored markers appeared, leaving the escape pod worked, and Ctrl+H hid and restored the markers. That short session had zero `ChargeIndicatorController.Update` exceptions and zero leftover TESTING chest-spawn messages. Purchase-related marker removal, stage transitions, multiplayer and long sessions remain untested. Other mods' errors are outside this repair. See `VALIDATION.md` for details.

**Package 1.0.1 is a packaging-only update.** It uses the exact same gameplay-tested DLL as package 1.0.0, so the plugin version shown in BepInEx remains 1.0.0. Source and build files are now published separately.

## 源码与致谢 / Source and credits

- [GitHub 源码、标准 .csproj 工程和构建说明](https://github.com/Saeey/LocaterFix)。
- 原版作者：**Hyru / Hyrulien**；补丁发布者：**for_null**。开发使用 AI 辅助，已标注 AI Generated。
- 安装包仅包含补丁 DLL、用户文档、许可证和新图标；源码与构建文件单独放在 GitHub，不附带原版 Locater 文件。

- [Source repository and standard dotnet build instructions](https://github.com/Saeey/LocaterFix).
- Original Locater: **Hyru / Hyrulien**. Original code and assets remain with their author.
- Companion patch: **for_null**, developed with AI assistance and tagged AI Generated.
- This installation ZIP contains only the companion DLL, user documentation, license and a new icon. Source, build scripts and original Locater files are excluded.

## 中文说明

这是官方原版 Locater 1.3.5 的独立补丁，修复标记组件持续空引用报错和遗留测试代码生成箱子的问题。需要同时启用原版 Locater，安装后重启游戏。1.0.1 仅调整打包与源码链接，沿用已实测的 DLL，因此启动日志中的插件版本仍是 1.0.0。源码与标准 .csproj 工程已放在上方 GitHub 仓库，安装包不再附带源码或构建脚本。联机、跨关卡和长时间游玩尚未验证。
