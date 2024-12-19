﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations.Identity
{
    internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(TableNames.AppUsers);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDirector).HasDefaultValue(false);
            builder.Property(x => x.IsHeadOfDepartment).HasDefaultValue(false);
            builder.Property(x => x.ManagerId).HasDefaultValue(null);
            builder.Property(x => x.IsReceipient).HasDefaultValue(-1);

            // Each user can have many UserClaims
            builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            // Each user can have many UserLogins
            builder.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            // Each user can have many UserTokens
            builder.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            // Each user can have many UserTokens
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
