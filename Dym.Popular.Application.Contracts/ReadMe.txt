﻿项目主要包含 应用服务 interfaces 和应用层的 数据传输对象 (DTO). 它用于分离应用层的接口和实现. 这种方式可以将接口项目做为约定包共享给客户端.

例如 IBookAppService 接口和 BookCreationDto 类都适合放在这个项目中.

它依赖 .Domain.Shared 因为它可能会在应用接口和DTO中使用常量,枚举和其他的共享对象.