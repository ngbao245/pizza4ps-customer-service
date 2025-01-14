using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvince
{
    public class GetListProvinceQueryHandler : IRequestHandler<GetListProvinceQuery, GetListProvinceQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public GetListProvinceQueryHandler(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<GetListProvinceQueryResponse> Handle(GetListProvinceQuery request, CancellationToken cancellationToken)
        {
            var query = _provinceRepository.GetListAsNoTracking(
                x => request.GetListProvinceDto.Name == null || x.Name.Contains(request.GetListProvinceDto.Name),
                includeProperties: request.GetListProvinceDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListProvinceDto.SortBy)
                .Skip(request.GetListProvinceDto.SkipCount).Take(request.GetListProvinceDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProvinceErrorConstant.PROVINCE_NOT_FOUND);
            var result = _mapper.Map<List<ProvinceDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListProvinceQueryResponse(result, totalCount);
        }
    }
}