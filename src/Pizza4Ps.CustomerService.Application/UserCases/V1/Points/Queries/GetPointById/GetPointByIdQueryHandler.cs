using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Points.Queries.GetPointById
{
    public class GetPointByIdQueryHandler : IRequestHandler<GetPointByIdQuery, PointDto>
    {
        private readonly IMapper _mapper;
        private readonly IPointRepository _pointRepository;

        public GetPointByIdQueryHandler(IMapper mapper, IPointRepository pointRepository)
        {
            _mapper = mapper;
            _pointRepository = pointRepository;
        }

        public async Task<PointDto> Handle(GetPointByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _pointRepository.GetSingleByIdAsync(request.Id, request.IncludeProperties);
            var result = _mapper.Map<PointDto>(entity);
            return result;
        }
    }
}