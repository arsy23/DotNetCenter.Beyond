namespace DotNetCenter.Beyond.Mapping
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtension
    {
        /// <summary>
        /// Projection from queryable model
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable">Queryable Model</param>
        /// <param name="mapper">AutoMapper Mapper from DotNetCenter.Byond.A</param>
        /// <returns></returns>
        public static async Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IMapper mapper) 
            => await queryable
            .ProjectTo<TDestination>(mapper.ConfigurationProvider)
            .ToListAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static IQueryable<TDestination> ProjectToQueryable<TDestination>(this IQueryable queryable, IMapper mapper) 
            => queryable
            .ProjectTo<TDestination>(mapper.ConfigurationProvider);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<TDestination> ProjectToSingleOrDefaultAsync<TDestination>(this IQueryable queryable, IMapper mapper) 
            => await queryable
            .ProjectTo<TDestination>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}