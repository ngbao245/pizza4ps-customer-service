using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict
{
    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, PaginatedResultDto<DistrictDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public GetListDistrictQueryHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<PaginatedResultDto<DistrictDto>> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            var query = _districtRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.ProvinceId == null || x.ProvinceId == request.ProvinceId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.DistrictErrorConstant.DISTRICT_NOT_FOUND);
            var result = _mapper.Map<List<DistrictDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<DistrictDto>(result, totalCount);
        }
    }
}