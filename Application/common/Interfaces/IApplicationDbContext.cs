using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Unit> Units { get; }
        public DbSet<InstallmentPlan> InstallmentPlans { get; }
        public DbSet<UserPaymentUnit> UserPaymentUnits { get; }
        public DbSet<UserPaymentUnitInstallment> UserPaymentUnitInstallments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
