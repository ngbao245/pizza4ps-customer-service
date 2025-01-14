﻿using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories.RepositoryBase;
using Pizza4Ps.CustomerService.Domain.Entities;

namespace Pizza4Ps.CustomerService.Domain.Abstractions.Repositories
{
    public interface IPointRepository : IRepositoryBase<Point, Guid>
    {
    }
}
