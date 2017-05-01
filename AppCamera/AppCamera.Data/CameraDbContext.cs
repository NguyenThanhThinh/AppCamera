using AppCamera.Entities.Enitities;
using System.Data.Entity;

namespace AppCamera.Data
{
    public class CameraDbContext:DbContext
    {
        public CameraDbContext()
            : base("name=AppCameraPetProject")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Camera> Cameras { get; set; }

        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camera>().Property(camera => camera.Price).HasPrecision(16, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
