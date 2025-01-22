using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard
{
    public class GetListWardQueryHandler : IRequestHandler<GetListWardQuery, PaginatedResultDto<WardDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;

        public GetListWardQueryHandler(IMapper mapper, IWardRepository wardRepository)
        {
            _mapper = mapper;
            _wardRepository = wardRepository;
        }

        public async Task<PaginatedResultDto<WardDto>> Handle(GetListWardQuery request, CancellationToken cancellationToken)
        {
            var query = _wardRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.DistrictId == null || x.DistrictId == request.DistrictId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.WardErrorConstant.WARD_NOT_FOUND);
            var result = _mapper.Map<List<WardDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WardDto>(result, totalCount);
        }
    }
}