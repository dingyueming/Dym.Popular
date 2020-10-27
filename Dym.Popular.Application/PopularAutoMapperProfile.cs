using AutoMapper;
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
            var exEntityTypes = exEntityAassembly.GetTypes();
            foreach (var entityType in entityTypes)
            {
                var exTypeName = entityType.Name.Replace("Entity", "") + "Dto";
                var listExEntityType = exEntityTypes.Where(x => x.Name == exTypeName).ToList();
                foreach (var exEntityType in listExEntityType)
                {
                    CreateMap(entityType, exEntityType);
                    CreateMap(exEntityType, entityType);
                }
            }
        }
    }
}
