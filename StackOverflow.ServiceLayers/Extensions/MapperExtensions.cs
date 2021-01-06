using AutoMapper;

namespace StackOverflow.ServiceLayers.Extensions
{
    public static class MapperExtensions
    {
        private static void IgnoreUnmappedProperties(TypeMap typeMap, IMappingExpression mappingExpression)
        {
            foreach (var propertyName in typeMap.GetUnmappedPropertyNames())
            {
                if (typeMap.SourceType.GetProperty(propertyName) != null)
                {
                    mappingExpression.ForMember(propertyName, memberOptions => memberOptions.Ignore());
                }
                if (typeMap.DestinationType.GetProperty(propertyName) != null)
                {
                    mappingExpression.ForMember(propertyName, memberOptions => memberOptions.Ignore());
                }
            }
        }

        public static void IgnoreUnmapped(this IProfileExpression profileExpression)
        {
            profileExpression.ForAllMaps(IgnoreUnmappedProperties);
        }
    }
}
