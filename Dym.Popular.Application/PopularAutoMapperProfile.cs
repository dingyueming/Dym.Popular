using AutoMapper;
using Dym.Popular.Application.Contracts.Dto.Mis;
using System.Linq;

namespace Dym.Popular.Application
{
    public class PopularAutoMapperProfile : Profile
    {
        public PopularAutoMapperProfile()
        {
            SetMapperInstence();
        }
        /// <summary>
        /// 实体和扩展实体映射初始化
        /// </summary>
        private void SetMapperInstence()
        {
            var entityAassembly = System.Reflection.Assembly.Load("Dym.Popular.Domain");
            var exEntityAassembly = System.Reflection.Assembly.Load("Dym.Popular.Application.Contracts");
            var entityTypes = entityAassembly.GetTypes();
            var dtoTypes = exEntityAassembly.GetTypes();
            foreach (var entityType in entityTypes)
            {
                var dtoTypeName = entityType.Name.Replace("Entity", "") + "Dto";
                var dtoTypeList = dtoTypes.Where(x => x.Name == dtoTypeName).ToList();
                foreach (var dtoType in dtoTypeList)
                {
                    CreateMap(entityType, dtoType);
                    switch (dtoType.Name)
                    {
                        case nameof(DriverDto):
                            CreateMap(dtoType, entityType).ForMember("Unit", x => x.Ignore()).ForMember("Class", x => x.Ignore()).ForMember("Status", x => x.Ignore());
                            break;
                        case nameof(VehicleDto):
                            CreateMap(dtoType, entityType).ForMember("Unit", x => x.Ignore());
                            break;
                        default:
                            CreateMap(dtoType, entityType);
                            break;
                    }
                }
            }
        }
    }
}
