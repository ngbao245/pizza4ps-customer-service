using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWardIgnoreQueryFilter
{
    public class GetListWardIgnoreQueryFilterQueryHandler : IRequestHandler<GetListWardIgnoreQueryFilterQuery, GetListWardIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;

        public GetListWardIgnoreQueryFilterQueryHandler(IMapper mapper, IWardRepository wardRepository)
        {
            _mapper = mapper;
            _wardRepository = wardRepository;
        }

        public async Task<GetListWardIgnoreQueryFilterQueryResponse> Handle(GetListWardIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _wardRepository.GetListAsNoTracking(includeProperties: request.GetListWardIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListWardIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListWardIgnoreQueryFilterDto.Name))
                    && (request.GetListWardIgnoreQueryFilterDto.DistrictId == null || x.DistrictId == request.GetListWardIgnoreQueryFilterDto.DistrictId)
                    && x.IsDeleted == request.GetListWardIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListWardIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListWardIgnoreQueryFilterDto.SkipCount).Take(request.GetListWardIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<WardDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListWardIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}