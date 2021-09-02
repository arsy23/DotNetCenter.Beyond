namespace DotNetCenter.Beyond.Web.Core.Presenters
{

    using MediatR;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    public abstract class BasePresenter : ConfigurablePresenter
    {
        public BasePresenter(IHttpContextAccessor context) : base(context)
            => HttpContextAccessor = context;
        protected IMapper Mapper => _mapper ??= HttpContextAccessor.HttpContext.RequestServices.GetService<IMapper>();
        private IMapper _mapper;
        protected IMediator Mediator => _mediator ??= HttpContextAccessor.HttpContext.RequestServices.GetService<IMediator>();
        private IMediator _mediator;

    }
}
