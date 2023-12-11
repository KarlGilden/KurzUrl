using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class DataContext: DbContext
    {

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}
