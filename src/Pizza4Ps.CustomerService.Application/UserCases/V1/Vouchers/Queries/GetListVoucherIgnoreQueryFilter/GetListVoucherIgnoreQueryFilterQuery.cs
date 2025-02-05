using MediatR;
using Pizza4Ps.CustomerService.Application.Abstractions;
using Pizza4Ps.CustomerService.Application.DTOs;
using static Pizza4Ps.CustomerService.Domain.Enums.VoucherEnum;

namespace Pizza4Ps.CustomerService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<VoucherDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Code { get; set; }
        public DiscountTypeEnum? DiscountType { get; set; }
        public decimal? Value { get; set; }
        public int? PointUsed { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public VoucherStatusEnum? Status { get; set; }
        public Guid? CustomerId { get; set; }
    }
}