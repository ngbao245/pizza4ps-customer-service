﻿namespace Pizza4Ps.CustomerService.Application.Abstractions.Queries
{
    public class BaseGetSingleByIdQuery<TKey>
    {
        public TKey Id { get; set; }
    }
}