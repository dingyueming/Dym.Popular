项目包含 .Application.Contracts 项目的 应用服务 接口实现.

例如 BookAppService 类适合放在这个项目中.

它依赖 .Application.Contracts 项目, 因为它需要实现接口与使用DTO.
它依赖 .Domain 项目,因为它需要使用领域对象(实体,仓储接口等)执行应用程序逻辑.