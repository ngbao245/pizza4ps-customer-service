using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter
{
    public class GetListPointIgnoreQueryFilterQueryHandler : IRequestHandler<GetListPointIgnoreQueryFilterQuery, PaginatedResultDto<PointDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetListPointIgnoreQueryFilterQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<PaginatedResultDto<PointDto>> Handle(GetListPointIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _pointRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.Score == null || x.Score == request.Score)
                    && (request.ExpiryDate == null || x.ExpiryDate == request.ExpiryDate)
                    && (request.CustomerId == null || x.CustomerId == request.CustomerId)
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<PointDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<PointDto>(result, totalCount);
        }
    }
}