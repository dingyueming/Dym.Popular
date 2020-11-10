using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    /// <summary>
    /// Vehicle Comprehensive Statistics QueryDto
    /// </summary>
    public class VeComStaQueryDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
