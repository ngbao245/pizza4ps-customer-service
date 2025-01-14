using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCustomerIgnoreQueryFilterQuery, GetListCustomerIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerIgnoreQueryFilterQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetListCustomerIgnoreQueryFilterQueryResponse> Handle(GetListCustomerIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(includeProperties: request.GetListCustomerIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListCustomerIgnoreQueryFilterDto.FirstName == null || x.FirstName.Contains(request.GetListCustomerIgnoreQueryFilterDto.FirstName))
                    && (request.GetListCustomerIgnoreQueryFilterDto.LastName == null || x.LastName.Contains(request.GetListCustomerIgnoreQueryFilterDto.LastName))
                    && (request.GetListCustomerIgnoreQueryFilterDto.Gender == null || x.Gender == request.GetListCustomerIgnoreQueryFilterDto.Gender)
                    && (request.GetListCustomerIgnoreQueryFilterDto.DateOfBirth == null || x.DateOfBirth == request.GetListCustomerIgnoreQueryFilterDto.DateOfBirth)
                    && (request.GetListCustomerIgnoreQueryFilterDto.Email == null || x.Email.Contains(request.GetListCustomerIgnoreQueryFilterDto.Email))
                    && (request.GetListCustomerIgnoreQueryFilterDto.PhoneNumber == null || x.PhoneNumber.Contains(request.GetListCustomerIgnoreQueryFilterDto.PhoneNumber))
                    && (request.GetListCustomerIgnoreQueryFilterDto.Avatar == null || x.Avatar.Contains(request.GetListCustomerIgnoreQueryFilterDto.Avatar))
                    && (request.GetListCustomerIgnoreQueryFilterDto.StreetId == null || x.StreetId == request.GetListCustomerIgnoreQueryFilterDto.StreetId)
                    && x.IsDeleted == request.GetListCustomerIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListCustomerIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListCustomerIgnoreQueryFilterDto.SkipCount).Take(request.GetListCustomerIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCustomerIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}