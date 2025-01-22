﻿using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Enums;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<CustomerDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public Guid? StreetId { get; set; }
    }
}