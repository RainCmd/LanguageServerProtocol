# LanguageServerProtocol
基于[这个仓库](https://github.com/matarillo/LanguageServerProtocol)修改的支持.Net8.0的LSP的CSharp实现。

* 清理了一些不必要的脚本
* 消除了编译警告
* 修复一些小bug
* 请求的取消Token作为请求函数的第二个参数，并且是可选的
* 消息处理改为异步，避免在消息处理函数中发送请求导致卡死
* 对请求接口优化
* 部分接口的注释进行汉化
* 补充一些遗漏的参数和功能

# 其他
[语言服务器协议规范- 3.17](https://microsoft.github.io/language-server-protocol/specifications/lsp/3.17/specification)

[实现的语言服务器](https://microsoft.github.io/language-server-protocol/implementors/servers/)