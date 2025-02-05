using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreetIgnoreQueryFilter
{
    public class GetListStreetIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStreetIgnoreQueryFilterQuery, PaginatedResultDto<StreetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;

        public GetListStreetIgnoreQueryFilterQueryHandler(IMapper mapper, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
        }

        public async Task<PaginatedResultDto<StreetDto>> Handle(GetListStreetIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _streetRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.Name == null || x.Name.Contains(request.Name))
                    && (request.WardId == null || x.WardId == request.WardId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StreetDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StreetDto>(result, totalCount);
        }
    }
}