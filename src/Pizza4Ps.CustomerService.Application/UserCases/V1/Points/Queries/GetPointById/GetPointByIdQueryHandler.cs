using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Points;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetPointById
{
    public class GetPointByIdQueryHandler : IRequestHandler<GetPointByIdQuery, GetPointByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetPointByIdQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<GetPointByIdQueryResponse> Handle(GetPointByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _pointRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<PointDto>(entity);
            return new GetPointByIdQueryResponse
            {
                Point = result
            };
        }
    }
}