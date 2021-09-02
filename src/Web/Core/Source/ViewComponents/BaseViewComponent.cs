namespace DotNetCenter.Beyond.Web.Core.ViewComponents
{
    using global::AutoMapper;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    public abstract class BaseViewComponent : ConfigurableViewComponent
    {
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator _mediator;
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        private IMapper _mapper;
    }
}
