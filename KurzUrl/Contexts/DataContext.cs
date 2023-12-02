using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class DataContext: DbContext
    {
        static readonly string connectionString = "server=aws.connect.psdb.cloud;user=6cv5dlbue13r4w17z3mi;database=kurz-link;port=3306;password=pscale_pw_ADeatBQLtY7kt4g3sim97nruxKaSEolY7t223BhjB7;SslMode=VerifyFull";

        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
