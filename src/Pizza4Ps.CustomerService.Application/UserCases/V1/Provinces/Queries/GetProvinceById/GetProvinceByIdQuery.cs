using MediatR;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetProvinceById
{
    public class GetProvinceByIdQuery : IRequest<GetProvinceByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}