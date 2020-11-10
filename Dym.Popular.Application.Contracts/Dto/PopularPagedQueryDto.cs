using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto
{
    public class PopularPagedQueryDto
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int IsDelete { get; set; }

        public int ToSkipCount()
        {
            return (Page - 1) * Limit;
        }

        public int ToMaxResultCount()
        {
            return Limit;
        }
    }
}
