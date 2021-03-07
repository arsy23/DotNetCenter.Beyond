namespace DotNetCenter.Beyond.Web.Core.Presenters
{
    using System.Threading.Tasks;
    public interface Presentable<TInput, TOutput>
    {
        public Task<TOutput> Populate(TInput input);
    }
}
