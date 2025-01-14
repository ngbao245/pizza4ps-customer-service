using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Wards;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Wards.Queries.GetListWard
{
    public class GetListWardQueryHandler : IRequestHandler<GetListWardQuery, GetListWardQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;

        public GetListWardQueryHandler(IMapper mapper, IWardRepository wardRepository)
        {
            _mapper = mapper;
            _wardRepository = wardRepository;
        }

        public async Task<GetListWardQueryResponse> Handle(GetListWardQuery request, CancellationToken cancellationToken)
        {
            var query = _wardRepository.GetListAsNoTracking(
                x => (request.GetListWardDto.Name == null || x.Name.Contains(request.GetListWardDto.Name))
                && (request.GetListWardDto.DistrictId == null || x.DistrictId == request.GetListWardDto.DistrictId),
                includeProperties: request.GetListWardDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListWardDto.SortBy)
                .Skip(request.GetListWardDto.SkipCount).Take(request.GetListWardDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.WardErrorConstant.WARD_NOT_FOUND);
            var result = _mapper.Map<List<WardDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListWardQueryResponse(result, totalCount);
        }
    }
}