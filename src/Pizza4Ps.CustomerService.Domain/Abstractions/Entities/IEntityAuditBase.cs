﻿namespace Pizza4Ps.CustomerService.Domain.Abstractions.Entities
{
    public interface IEntityAuditBase<TKey> : IEntityBase<TKey>, IAuditable
    {
    }
}
