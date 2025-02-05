using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetProvinceById
{
    public class GetProvinceByIdQueryHandler : IRequestHandler<GetProvinceByIdQuery, ProvinceDto>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public GetProvinceByIdQueryHandler(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<ProvinceDto> Handle(GetProvinceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _provinceRepository.GetSingleByIdAsync(request.Id, request.IncludeProperties);
            var result = _mapper.Map<ProvinceDto>(entity);
            return result;
        }
    }
}