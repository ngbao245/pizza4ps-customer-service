﻿namespace Pizza4Ps.CustomerService.Domain.Abstractions.Entities
{
    public interface IDateTracking
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
    }
}