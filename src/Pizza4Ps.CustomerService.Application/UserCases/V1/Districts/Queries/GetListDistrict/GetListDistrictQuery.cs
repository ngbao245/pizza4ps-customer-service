using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict
{
    public class GetListDistrictQuery : IRequest<GetListDistrictQueryResponse>
    {
        public GetListDistrictDto GetListDistrictDto { get; set; }
    }
}