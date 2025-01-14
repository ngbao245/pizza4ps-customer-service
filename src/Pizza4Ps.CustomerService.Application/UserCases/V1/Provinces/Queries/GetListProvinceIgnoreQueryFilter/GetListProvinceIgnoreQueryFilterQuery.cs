using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvinceIgnoreQueryFilter
{
    public class GetListProvinceIgnoreQueryFilterQuery : IRequest<GetListProvinceIgnoreQueryFilterQueryResponse>
    {
        public GetListProvinceIgnoreQueryFilterDto GetListProvinceIgnoreQueryFilterDto { get; set; }
    }
}