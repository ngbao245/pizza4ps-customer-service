using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetDistrictById
{
    public class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, DistrictDto>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public GetDistrictByIdQueryHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<DistrictDto> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _districtRepository.GetSingleByIdAsync(request.Id, request.IncludeProperties);
            var result = _mapper.Map<DistrictDto>(entity);
            return result;
        }
    }
}