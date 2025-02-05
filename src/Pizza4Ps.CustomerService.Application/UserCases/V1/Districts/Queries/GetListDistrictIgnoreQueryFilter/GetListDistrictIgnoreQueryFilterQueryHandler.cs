using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter
{
    public class GetListDistrictIgnoreQueryFilterQueryHandler : IRequestHandler<GetListDistrictIgnoreQueryFilterQuery, PaginatedResultDto<DistrictDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public GetListDistrictIgnoreQueryFilterQueryHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<PaginatedResultDto<DistrictDto>> Handle(GetListDistrictIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _districtRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.Name == null || x.Name.Contains(request.Name))
                    && (request.ProvinceId == null || x.ProvinceId == request.ProvinceId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<DistrictDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<DistrictDto>(result, totalCount);
        }
    }
}