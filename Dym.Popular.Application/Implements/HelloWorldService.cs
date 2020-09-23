using Dym.Popular.Application.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular
{
    public class HelloWorldService : PopularAppService, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
