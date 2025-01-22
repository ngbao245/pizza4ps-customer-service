using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetProvinceById
{
    public class GetProvinceByIdQuery : IRequest<ProvinceDto>
    {
        public Guid Id { get; set; }
        public string IncludeProperties { get; set; } = "";
    }
}