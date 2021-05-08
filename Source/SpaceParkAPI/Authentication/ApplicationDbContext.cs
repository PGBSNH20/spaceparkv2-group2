using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpaceParkAPI.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=spaceparkdb,1433;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;");
            //optionsBuilder.UseSqlServer(@"Server=localhost,41434;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;");
            //optionsBuilder.UseSqlServer(@"Server=host.docker.internal,41434;Initial Catalog=SpaceParks;User Id=sa;Password=verystrong!pass123;");
            //optionsBuilder.UseSqlServer(@"Data Source=localhost,41434\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=SpaceParkTesting");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
