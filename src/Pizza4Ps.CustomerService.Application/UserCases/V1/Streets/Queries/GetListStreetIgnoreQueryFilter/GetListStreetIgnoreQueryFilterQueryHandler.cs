using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreetIgnoreQueryFilter
{
    public class GetListStreetIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStreetIgnoreQueryFilterQuery, GetListStreetIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;

        public GetListStreetIgnoreQueryFilterQueryHandler(IMapper mapper, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
        }

        public async Task<GetListStreetIgnoreQueryFilterQueryResponse> Handle(GetListStreetIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _streetRepository.GetListAsNoTracking(includeProperties: request.GetListStreetIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListStreetIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListStreetIgnoreQueryFilterDto.Name))
                    && (request.GetListStreetIgnoreQueryFilterDto.WardId == null || x.WardId == request.GetListStreetIgnoreQueryFilterDto.WardId)
                    && x.IsDeleted == request.GetListStreetIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListStreetIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListStreetIgnoreQueryFilterDto.SkipCount).Take(request.GetListStreetIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StreetDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStreetIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}