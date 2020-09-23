using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface
{
    public interface IHelloWorldService : IApplicationService
    {
        public string HelloWorld();
    }
}
