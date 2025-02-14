﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.CustomerService.Domain.Abstractions.Entities;
using Pizza4Ps.CustomerService.Domain.Entities;
using Pizza4Ps.CustomerService.Domain.Entities.Identity;
using Pizza4Ps.CustomerService.Persistence.Intercepter;
using System.Linq.Expressions;

namespace Pizza4Ps.CustomerService.Persistence
{
    public sealed class ApplicationDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly AuditSaveChangesInterceptor _auditInterceptor;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, AuditSaveChangesInterceptor auditInterceptor)
            : base(options)
        {
            _auditInterceptor = auditInterceptor;
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
                .Where(type => typeof(ISoftDelete).IsAssignableFrom(type)
                && type.IsClass
                && !type.IsAbstract);
            foreach (var softDeleteEntity in softDeleteEntities)
            {
                builder.Entity(softDeleteEntity).HasQueryFilter(GenerateQueryFilterLambda(softDeleteEntity));
            }
            builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        }

        private LambdaExpression? GenerateQueryFilterLambda(Type type)
        {
            var parameter = Expression.Parameter(type, "w");
            var falseConstantValue = Expression.Constant(false);
            var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
            var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
            var lambda = Expression.Lambda(equalExpression, parameter);
            return lambda;
        }

        #region Configuration DbSet
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Ward> Wards { get; set; }
        #endregion
    }
}
