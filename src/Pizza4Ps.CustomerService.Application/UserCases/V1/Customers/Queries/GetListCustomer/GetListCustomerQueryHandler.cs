using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListCustomerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetListCustomerQueryResponse> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(
                x => (request.GetListCustomerDto.FirstName == null || x.FirstName.Contains(request.GetListCustomerDto.FirstName))
                && (request.GetListCustomerDto.LastName == null || x.LastName.Contains(request.GetListCustomerDto.LastName))
                && (request.GetListCustomerDto.Gender == null || x.Gender == request.GetListCustomerDto.Gender)
                && (request.GetListCustomerDto.DateOfBirth == null || x.DateOfBirth == request.GetListCustomerDto.DateOfBirth)
                && (request.GetListCustomerDto.Email == null || x.Email.Contains(request.GetListCustomerDto.Email))
                && (request.GetListCustomerDto.PhoneNumber == null || x.PhoneNumber.Contains(request.GetListCustomerDto.PhoneNumber))
                && (request.GetListCustomerDto.Avatar == null || x.Avatar.Contains(request.GetListCustomerDto.Avatar))
                && (request.GetListCustomerDto.StreetId == null || x.StreetId == request.GetListCustomerDto.StreetId),
                includeProperties: request.GetListCustomerDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListCustomerDto.SortBy)
                .Skip(request.GetListCustomerDto.SkipCount).Take(request.GetListCustomerDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.CustomerErrorConstant.CUSTOMER_NOT_FOUND);
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCustomerQueryResponse(result, totalCount);
        }
    }
}