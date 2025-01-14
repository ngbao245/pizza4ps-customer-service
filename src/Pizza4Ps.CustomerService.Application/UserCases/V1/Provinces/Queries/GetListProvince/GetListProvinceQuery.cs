using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvince
{
    public class GetListProvinceQuery : IRequest<GetListProvinceQueryResponse>
    {
        public GetListProvinceDto GetListProvinceDto { get; set; }
    }
}