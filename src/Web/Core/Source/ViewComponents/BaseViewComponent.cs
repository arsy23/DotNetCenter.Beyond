namespace DotNetCenter.Beyond.Web.Core.ViewComponents
{
    using global::AutoMapper;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    public abstract class BaseViewComponent : ConfigurableViewComponent
    {
        private IMediator _mediator;
        private IMapper _mapper;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
