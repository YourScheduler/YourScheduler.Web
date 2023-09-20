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
using FluentAssertions;
using System.Reflection.Emit;

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
        public virtual DbSet<TeamRoleFlags> TeamRolesFlags { get; set; }

        public YourSchedulerDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserTeams>()
                .HasOne(at => at.ApplicationUser)
                .WithMany(au => au.ApplicationUsersTeams)
                .HasForeignKey(at => at.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUserTeams>()
                .HasOne(at => at.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(t => t.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // seed data to database:
            builder.Entity<ApplicationUser>()
                .HasData(SeedData.GetUsersSeed());
            builder.Entity<Event>()
                .HasData(SeedData.GetEventsSeed());
            builder.Entity<TeamRoleFlags>()
                .HasData(SeedData.GetTeamRoleFlagsSeed());
            builder.Entity<TeamRole>()
                .HasData(SeedData.GetTeamRoleSeed());
            builder.Entity<Team>()
                .HasData(SeedData.GetTeamsSeed());
            builder.Entity<ApplicationUserEvents>()
                .HasData(SeedData.GetApplicationUserEventSeed());
            builder.Entity<ApplicationUserTeams>()
                .HasData(SeedData.GetApplicationUserTeamSeed());
        }
    }
}
