using AutoMapper;
using MediatR;
using Pizza4Ps.CustomerService.Application.DTOs.Vouchers;
using Pizza4Ps.CustomerService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetVoucherById
{
    public class GetVoucherByIdQueryHandler : IRequestHandler<GetVoucherByIdQuery, GetVoucherByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetVoucherByIdQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<GetVoucherByIdQueryResponse> Handle(GetVoucherByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _voucherRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<VoucherDto>(entity);
            return new GetVoucherByIdQueryResponse
            {
                Voucher = result
            };
        }
    }
}