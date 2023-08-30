using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourScheduler.Infrastructure.Entities;


namespace YourScheduler.Infrastructure
{
    public class YourSchedulerDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ApplicationUserEvents> ApplicationUsersEvents { get; set; }
        public virtual DbSet<ApplicationUserTeams> ApplicationUsersTeams { get; set; }

        public virtual DbSet<HomeView> HomeViews { get; set; }

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
            builder.Entity<HomeView>().HasData(SeedData.GetHomeViewSeed());
        }
    }
}
