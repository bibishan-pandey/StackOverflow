using AutoMapper;
using StackOverflow.ServiceLayers.Extensions;

namespace StackOverflow.ServiceLayers.Helpers
{
    public class CustomMapperConfiguration
    {
        public static IMapper ConfigCreateMapper<TModelA, TModelB>()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TModelA, TModelB>();
                c.IgnoreUnmapped();
            });
            return config.CreateMapper();
        }
    }
}
