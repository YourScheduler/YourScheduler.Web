using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using YourScheduler.Infrastructure.Entities;
using System.Buffers.Text;
using YourScheduler.Infrastructure;


namespace YourScheduler.Infrastructure
{
    public class YourSchedulerDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamRole> TeamRoles { get; set; }
        public virtual DbSet<ApplicationUserEvents> ApplicationUsersEvents { get; set; }
        public virtual DbSet<ApplicationUserTeams> ApplicationUsersTeams { get; set; }

        public YourSchedulerDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed data to database:
            builder.Entity<ApplicationUser>()
                .HasData(SeedData.GetUsersSeed());
            builder.Entity<Event>()
                .HasData(SeedData.GetEventsSeed());
            builder.Entity<Team>()
                .HasData(SeedData.GetTeamsSeed());
            builder.Entity<ApplicationUserEvents>()
                .HasData(SeedData.GetApplicationUserEventSeed());
            builder.Entity<ApplicationUserTeams>()
                .HasData(SeedData.GetApplicationUserTeamSeed());
        }
    }
}
