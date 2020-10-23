﻿using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.Entities.Mis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Mis
{
    /// <summary>
    /// IPostRepository
    /// </summary>
    public interface IVehicleRepository : IRepository<VehicleEntity, int>
    {
        Task BulkInsertAsync(IEnumerable<VehicleEntity> vehicleEntities);
    }
}
