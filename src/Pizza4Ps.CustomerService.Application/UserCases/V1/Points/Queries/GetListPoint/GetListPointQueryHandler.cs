using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint
{
    public class GetListPointQueryHandler : IRequestHandler<GetListPointQuery, PaginatedResultDto<PointDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetListPointQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<PaginatedResultDto<PointDto>> Handle(GetListPointQuery request, CancellationToken cancellationToken)
        {
            var query = _pointRepository.GetListAsNoTracking(
                x => (request.Score == null || x.Score == request.Score)
                && (request.ExpiryDate == null || x.ExpiryDate == request.ExpiryDate)
                && (request.CustomerId == null || x.CustomerId == request.CustomerId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.PointErrorConstant.POINT_NOT_FOUND);
            var result = _mapper.Map<List<PointDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<PointDto>(result, totalCount);
        }
    }
}