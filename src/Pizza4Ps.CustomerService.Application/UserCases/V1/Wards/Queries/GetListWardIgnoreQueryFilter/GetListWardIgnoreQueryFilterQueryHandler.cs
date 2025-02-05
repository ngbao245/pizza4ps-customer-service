using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter
{
    public class GetListWardIgnoreQueryFilterQueryHandler : IRequestHandler<GetListWardIgnoreQueryFilterQuery, PaginatedResultDto<WardDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;

        public GetListWardIgnoreQueryFilterQueryHandler(IMapper mapper, IWardRepository wardRepository)
        {
            _mapper = mapper;
            _wardRepository = wardRepository;
        }

        public async Task<PaginatedResultDto<WardDto>> Handle(GetListWardIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _wardRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.Name == null || x.Name.Contains(request.Name))
                    && (request.DistrictId == null || x.DistrictId == request.DistrictId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<WardDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WardDto>(result, totalCount);
        }
    }
}