using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class DataContext: DbContext
    {

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration["ConnectionStrings:Default"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:Default"]));
        }
    }
}
