using Microsoft.AspNetCore.Identity;
using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;

namespace Pizza4Ps.PizzaService.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>, IAuditable
    {
        public string Description { get; set; }
        public string RoleCode { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }
        public virtual ICollection<IdentityRoleClaim<Guid>> Claims { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
