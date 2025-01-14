using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrictIgnoreQueryFilter
{
    public class GetListDistrictIgnoreQueryFilterQueryHandler : IRequestHandler<GetListDistrictIgnoreQueryFilterQuery, GetListDistrictIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public GetListDistrictIgnoreQueryFilterQueryHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<GetListDistrictIgnoreQueryFilterQueryResponse> Handle(GetListDistrictIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _districtRepository.GetListAsNoTracking(includeProperties: request.GetListDistrictIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListDistrictIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListDistrictIgnoreQueryFilterDto.Name))
                    && (request.GetListDistrictIgnoreQueryFilterDto.ProvinceId == null || x.ProvinceId == request.GetListDistrictIgnoreQueryFilterDto.ProvinceId)
                    && x.IsDeleted == request.GetListDistrictIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListDistrictIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListDistrictIgnoreQueryFilterDto.SkipCount).Take(request.GetListDistrictIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<DistrictDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListDistrictIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}