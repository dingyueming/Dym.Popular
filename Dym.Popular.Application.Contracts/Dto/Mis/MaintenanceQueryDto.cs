using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class MaintenanceQueryDto : PopularPagedQueryDto
    {
        public string License { get; set; }
    }
}
