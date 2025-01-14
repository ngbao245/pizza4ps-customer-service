using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Streets;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreet
{
    public class GetListStreetQueryHandler : IRequestHandler<GetListStreetQuery, GetListStreetQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;

        public GetListStreetQueryHandler(IMapper mapper, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
        }

        public async Task<GetListStreetQueryResponse> Handle(GetListStreetQuery request, CancellationToken cancellationToken)
        {
            var query = _streetRepository.GetListAsNoTracking(
                x => (request.GetListStreetDto.Name == null || x.Name.Contains(request.GetListStreetDto.Name))
                && (request.GetListStreetDto.WardId == null || x.WardId == request.GetListStreetDto.WardId),
                includeProperties: request.GetListStreetDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListStreetDto.SortBy)
                .Skip(request.GetListStreetDto.SkipCount).Take(request.GetListStreetDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StreetErrorConstant.STREET_NOT_FOUND);
            var result = _mapper.Map<List<StreetDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStreetQueryResponse(result, totalCount);
        }
    }
}