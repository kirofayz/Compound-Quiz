using Application.common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<InstallmentPlan> InstallmentPlans { get; set; }

        public DbSet<UserPaymentUnit> UserPaymentUnits { get; set; }

        public DbSet<UserPaymentUnitInstallment> UserPaymentUnitInstallments { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            SeedInitialData(builder);

        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // seed data for user
             modelBuilder.Entity<User>().HasData(
                new User { Id = 1 , Name = "Kerolos Fayez" , Email = "kirofayez23@gmail.com" , Phone = "01202982836" , Password = HashPassword("kero@123")},
                new User { Id = 2 , Name = "Mo Salah" , Email = "mosalah@gmail.com" , Phone = "01202982835" , Password = HashPassword("Mo@123")}
                );

            // seed data for unit
            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1 , UnitName = "400" , RoomCount = 3 , Floor = 1 , View = "Nile" , AvailabilityStatus = true},
                new Unit { Id = 2, UnitName = "401", RoomCount = 4, Floor = 1, View = "Nile", AvailabilityStatus = true },
                new Unit { Id = 3, UnitName = "402", RoomCount = 2, Floor = 2, View = "City", AvailabilityStatus = false },
                new Unit { Id = 4, UnitName = "403", RoomCount = 3, Floor = 2, View = "Nile", AvailabilityStatus = true },
                new Unit { Id = 5, UnitName = "404", RoomCount = 3, Floor = 3, View = "City", AvailabilityStatus = true }
                );


            // seed data for InstallmentPlan
            modelBuilder.Entity<InstallmentPlan>().HasData(
                new InstallmentPlan { Id = 1 , PlanName = "Yearly" } ,
                new InstallmentPlan { Id = 2, PlanName = "Quarterly" },
                new InstallmentPlan { Id = 3, PlanName = "Semi-Annual" },
                new InstallmentPlan { Id = 4, PlanName = "Monthly " }
                );
           
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
  
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert to base64
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }
    }
}
