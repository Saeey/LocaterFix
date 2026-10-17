# 更新日志 / Changelog

## 1.0.1

- 根据版主建议，源码和构建文件移出安装包，单独放入 GitHub。
- 提供标准 .csproj 工程，以及 GitHub / Thunderstore 中英双语介绍。
- 保留已实测的 1.0.0 DLL，不修改运行逻辑；BepInEx 插件版本仍为 1.0.0。

- Packaging-only revision following moderator guidance.
- Remove source code and build scripts from the installation ZIP.
- Link the separate GitHub source repository with an SDK-style .csproj and dotnet build instructions.
- Preserve the exact gameplay-tested 1.0.0 DLL; no runtime behavior changes. BepInEx still reports plugin version 1.0.0.

## 1.0.0

- Initial standalone companion for official Hyru-Locater 1.3.5.
- Disable the charge updater on Locater's static markers before cleanup, preserve marker colors and hide unused text.
- Remove only Locater's leftover test-chest scene postfix.
- Check the supported original binary's version and SHA-256 before applying patches.
