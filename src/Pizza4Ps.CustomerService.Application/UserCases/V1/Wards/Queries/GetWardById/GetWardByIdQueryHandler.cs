using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetWardById
{
    public class GetWardByIdQueryHandler : IRequestHandler<GetWardByIdQuery, WardDto>
    {
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;

        public GetWardByIdQueryHandler(IMapper mapper, IWardRepository wardRepository)
        {
            _mapper = mapper;
            _wardRepository = wardRepository;
        }

        public async Task<WardDto> Handle(GetWardByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _wardRepository.GetSingleByIdAsync(request.Id, request.IncludeProperties);
            var result = _mapper.Map<WardDto>(entity);
            return result;
        }
    }
}