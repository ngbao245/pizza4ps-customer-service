using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Customers;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQuery : IRequest<GetListCustomerIgnoreQueryFilterQueryResponse>
    {
        public GetListCustomerIgnoreQueryFilterDto GetListCustomerIgnoreQueryFilterDto { get; set; }
    }
}