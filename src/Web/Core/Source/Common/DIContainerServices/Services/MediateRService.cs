using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public class MediateRService 
        : SupportMediateR
    {
        #region Constructor
        public MediateRService(IMediator mediator) => _mediator = mediator;
        #endregion

        public IMediator Mediator => _mediator;
        private readonly IMediator _mediator;

    }
}
