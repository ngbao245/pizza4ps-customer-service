using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Provinces;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvinceIgnoreQueryFilter
{
    public class GetListProvinceIgnoreQueryFilterQueryHandler : IRequestHandler<GetListProvinceIgnoreQueryFilterQuery, GetListProvinceIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public GetListProvinceIgnoreQueryFilterQueryHandler(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<GetListProvinceIgnoreQueryFilterQueryResponse> Handle(GetListProvinceIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _provinceRepository.GetListAsNoTracking(includeProperties: request.GetListProvinceIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListProvinceIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListProvinceIgnoreQueryFilterDto.Name))
                    && x.IsDeleted == request.GetListProvinceIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListProvinceIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListProvinceIgnoreQueryFilterDto.SkipCount).Take(request.GetListProvinceIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ProvinceDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListProvinceIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}