using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Http;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public class AutoMapperService 
        : SupportAutoMapper
    {
        #region Constructor
        public AutoMapperService(IMapper mapper) => _mapper = mapper;
        #endregion
        public IMapper Mapper => _mapper;
        private readonly IMapper _mapper;

    }
}
