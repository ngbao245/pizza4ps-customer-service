using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Points;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPointIgnoreQueryFilter
{
    public class GetListPointIgnoreQueryFilterQueryHandler : IRequestHandler<GetListPointIgnoreQueryFilterQuery, GetListPointIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetListPointIgnoreQueryFilterQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<GetListPointIgnoreQueryFilterQueryResponse> Handle(GetListPointIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _pointRepository.GetListAsNoTracking(includeProperties: request.GetListPointIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListPointIgnoreQueryFilterDto.Score == null || x.Score == request.GetListPointIgnoreQueryFilterDto.Score)
                    && (request.GetListPointIgnoreQueryFilterDto.ExpiryDate == null || x.ExpiryDate == request.GetListPointIgnoreQueryFilterDto.ExpiryDate)
                    && (request.GetListPointIgnoreQueryFilterDto.CustomerId == null || x.CustomerId == request.GetListPointIgnoreQueryFilterDto.CustomerId)
                    && x.IsDeleted == request.GetListPointIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListPointIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListPointIgnoreQueryFilterDto.SkipCount).Take(request.GetListPointIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<PointDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListPointIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}