using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Streets.Queries.GetListStreet
{
    public class GetListStreetQueryHandler : IRequestHandler<GetListStreetQuery, PaginatedResultDto<StreetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStreetRepository _streetRepository;

        public GetListStreetQueryHandler(IMapper mapper, IStreetRepository streetRepository)
        {
            _mapper = mapper;
            _streetRepository = streetRepository;
        }

        public async Task<PaginatedResultDto<StreetDto>> Handle(GetListStreetQuery request, CancellationToken cancellationToken)
        {
            var query = _streetRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.WardId == null || x.WardId == request.WardId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StreetErrorConstant.STREET_NOT_FOUND);
            var result = _mapper.Map<List<StreetDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StreetDto>(result, totalCount);
        }
    }
}