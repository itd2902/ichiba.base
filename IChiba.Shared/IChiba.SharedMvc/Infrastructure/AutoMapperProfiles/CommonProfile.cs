using System;
using AutoMapper;
using IChiba.Core.Infrastructure.Mapper;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Infrastructure.AutoMapperProfiles
{
    public class CommonProfile : Profile, IOrderedMapperProfile
    {
        public static Action<TypeMap, IMappingExpression> AllMapsAction = (mapConfiguration, map) =>
        {
            //exclude Form and CustomProperties from mapping BaseNopModel
            if (typeof(BaseIChibaModel).IsAssignableFrom(mapConfiguration.DestinationType))
            {
                //map.ForMember(nameof(BaseNopModel.Form), options => options.Ignore());
                map.ForMember(nameof(BaseIChibaModel.CustomProperties), options => options.Ignore());
            }
        };

        public CommonProfile()
        {
            // Custom-MongoDB
            // special mapper, that avoids DbUpdate exceptions in cases where
            // optional (nullable) int FK properties are 0 instead of null 
            // after mapping model > entity.
            // if type is nullable source value shouldn't be touched
            var fkConverter = new OptionalFkConverter();
            CreateMap<int?, int?>().ConvertUsing(fkConverter);
            CreateMap<int, int?>().ConvertUsing(fkConverter);

            //add some generic mapping rules
            ForAllMaps(AllMapsAction);
        }

        public int Order => 0;
    }

    public class OptionalFkConverter : ITypeConverter<int?, int?>, ITypeConverter<int, int?>
    {
        public int? Convert(int? source, int? destination, ResolutionContext context)
        {
            return source;
        }

        public int? Convert(int source, int? destination, ResolutionContext context)
        {
            return source == 0 ? (int?)null : source;
        }
    }
}
