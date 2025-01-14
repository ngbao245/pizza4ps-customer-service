using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Application.DTOs.Districts;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;
using Pizza4Ps.CustomerService.Domain.Constants;
using Pizza4Ps.CustomerService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Districts.Queries.GetListDistrict
{
    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, GetListDistrictQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public GetListDistrictQueryHandler(IMapper mapper, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
        }

        public async Task<GetListDistrictQueryResponse> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            var query = _districtRepository.GetListAsNoTracking(
                x => (request.GetListDistrictDto.Name == null || x.Name.Contains(request.GetListDistrictDto.Name))
                && (request.GetListDistrictDto.ProvinceId == null || x.ProvinceId == request.GetListDistrictDto.ProvinceId),
                includeProperties: request.GetListDistrictDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListDistrictDto.SortBy)
                .Skip(request.GetListDistrictDto.SkipCount).Take(request.GetListDistrictDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.DistrictErrorConstant.DISTRICT_NOT_FOUND);
            var result = _mapper.Map<List<DistrictDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListDistrictQueryResponse(result, totalCount);
        }
    }
}