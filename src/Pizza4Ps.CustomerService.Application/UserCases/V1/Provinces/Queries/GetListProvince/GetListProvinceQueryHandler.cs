using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvince
{
    public class GetListProvinceQueryHandler : IRequestHandler<GetListProvinceQuery, PaginatedResultDto<ProvinceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public GetListProvinceQueryHandler(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<PaginatedResultDto<ProvinceDto>> Handle(GetListProvinceQuery request, CancellationToken cancellationToken)
        {
            var query = _provinceRepository.GetListAsNoTracking(
                x => request.Name == null || x.Name.Contains(request.Name),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProvinceErrorConstant.PROVINCE_NOT_FOUND);
            var result = _mapper.Map<List<ProvinceDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProvinceDto>(result, totalCount);
        }
    }
}