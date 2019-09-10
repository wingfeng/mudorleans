# mudorleans
基于[Orleans](https://github.com/dotnet/orleans)，构建一个类 [FY4](https://github.com/mudchina/fy4) 的微服务游戏后端架构，实现游戏服务的弹性扩展。 
登录Mud你可以用[Mudlet](https://www.mudlet.org/zh/)或者简单的Telnet localhost 4444来访问使用。
通过helm chart定义服务角色间的关系和部署架构，将应用发布到Kubernetes群集中。
代码的构建基于Azure DevOps进行构建和发布。实现代码提交自动构建自动发布到Kubernetes群集中。
