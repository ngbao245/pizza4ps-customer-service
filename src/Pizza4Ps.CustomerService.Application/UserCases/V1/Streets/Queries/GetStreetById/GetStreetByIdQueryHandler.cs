using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetStreetById
{
    public class GetStreetByIdQueryHandler : IRequestHandler<GetStreetByIdQuery, GetStreetByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;

        public GetStreetByIdQueryHandler(IMapper mapper, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
        }

        public async Task<GetStreetByIdQueryResponse> Handle(GetStreetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _streetRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StreetDto>(entity);
            return new GetStreetByIdQueryResponse
            {
                Street = result
            };
        }
    }
}