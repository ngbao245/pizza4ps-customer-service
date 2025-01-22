using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, PaginatedResultDto<CustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<PaginatedResultDto<CustomerDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(
                x => (request.FirstName == null || x.FirstName.Contains(request.FirstName))
                && (request.LastName == null || x.LastName.Contains(request.LastName))
                && (request.Gender == null || x.Gender == request.Gender)
                && (request.DateOfBirth == null || x.DateOfBirth == request.DateOfBirth)
                && (request.Email == null || x.Email.Contains(request.Email))
                && (request.PhoneNumber == null || x.PhoneNumber.Contains(request.PhoneNumber))
                && (request.Avatar == null || x.Avatar.Contains(request.Avatar))
                && (request.StreetId == null || x.StreetId == request.StreetId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.CustomerErrorConstant.CUSTOMER_NOT_FOUND);
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<CustomerDto>(result, totalCount);
        }
    }
}