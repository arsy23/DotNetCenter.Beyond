namespace DotNetCenter.Beyond.Mapping
{
    using AutoMapper;
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapTo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile) 
            => profile.CreateMap(GetType(), typeof(T));
    }
}
