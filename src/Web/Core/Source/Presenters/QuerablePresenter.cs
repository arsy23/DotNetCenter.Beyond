namespace DotNetCenter.Beyond.Web.Core.Presenters
{
    using System.Linq;
    public interface QuerablePresenter<TInput, TOutput> where TInput : class where TOutput : class
    {
        public IQueryable<TOutput> Populate(TInput request);
    }
}
