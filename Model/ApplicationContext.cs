using Microsoft.EntityFrameworkCore;

namespace DbProject.Model
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<HostGuide> HostGuides { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceHost> PlaceHosts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TouristGuide> TouristGuides { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=couchsurfingdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}