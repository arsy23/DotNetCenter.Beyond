using AutoMapper;

namespace DotNetCenter.Beyond.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile) 
            => profile.CreateMap(typeof(T), GetType());
    }
}
