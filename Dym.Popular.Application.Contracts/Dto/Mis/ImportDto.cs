using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class ImportDto<T>
    {
        public object[] Header { get; set; }

        public List<T> Data { get; set; }
    }
}
