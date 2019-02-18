
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sup.Models
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        
        public DbSet<Group> Groups {get; set;}
        public DbSet<Message> Messages {get; set;}
        public DbSet<Company> Companies {get; set;}
        //public DbSet<Industry> Industries {get; set;}
        public DbSet<Country> Countries {get; set;}
        public DbSet<City> Cities {get; set;}
        //public DbSet<Keyword> Keywords {get;set;}
        public DbSet<Event> Events { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<EventUser> EventUsers {get;set;}
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    
}