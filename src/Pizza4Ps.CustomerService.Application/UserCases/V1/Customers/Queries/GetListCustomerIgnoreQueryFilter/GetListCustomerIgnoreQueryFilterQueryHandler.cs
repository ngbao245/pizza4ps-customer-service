using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCustomerIgnoreQueryFilterQuery, PaginatedResultDto<CustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerIgnoreQueryFilterQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<PaginatedResultDto<CustomerDto>> Handle(GetListCustomerIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.FirstName == null || x.FirstName.Contains(request.FirstName))
                    && (request.LastName == null || x.LastName.Contains(request.LastName))
                    && (request.Gender == null || x.Gender == request.Gender)
                    && (request.DateOfBirth == null || x.DateOfBirth == request.DateOfBirth)
                    && (request.Email == null || x.Email.Contains(request.Email))
                    && (request.PhoneNumber == null || x.PhoneNumber.Contains(request.PhoneNumber))
                    && (request.Avatar == null || x.Avatar.Contains(request.Avatar))
                    && (request.StreetId == null || x.StreetId == request.StreetId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<CustomerDto>(result, totalCount);
        }
    }
}