using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Provinces.Queries.GetListProvinceIgnoreQueryFilter
{
    public class GetListProvinceIgnoreQueryFilterQueryHandler : IRequestHandler<GetListProvinceIgnoreQueryFilterQuery, PaginatedResultDto<ProvinceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public GetListProvinceIgnoreQueryFilterQueryHandler(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<PaginatedResultDto<ProvinceDto>> Handle(GetListProvinceIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _provinceRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.Name == null || x.Name.Contains(request.Name))
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ProvinceDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProvinceDto>(result, totalCount);
        }
    }
}