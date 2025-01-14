using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Points;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetListPoint
{
    public class GetListPointQueryHandler : IRequestHandler<GetListPointQuery, GetListPointQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetListPointQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<GetListPointQueryResponse> Handle(GetListPointQuery request, CancellationToken cancellationToken)
        {
            var query = _pointRepository.GetListAsNoTracking(
                x => (request.GetListPointDto.Score == null || x.Score == request.GetListPointDto.Score)
                && (request.GetListPointDto.ExpiryDate == null || x.ExpiryDate == request.GetListPointDto.ExpiryDate)
                && (request.GetListPointDto.CustomerId == null || x.CustomerId == request.GetListPointDto.CustomerId),
                includeProperties: request.GetListPointDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListPointDto.SortBy)
                .Skip(request.GetListPointDto.SkipCount).Take(request.GetListPointDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.PointErrorConstant.POINT_NOT_FOUND);
            var result = _mapper.Map<List<PointDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListPointQueryResponse(result, totalCount);
        }
    }
}