using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class DataContext: DbContext
    {
        static readonly string connectionString = "server=aws.connect.psdb.cloud;user=84xlbjy5l391ybxqqngz;database=kurz-link;port=3306;password=pscale_pw_VxDtka0fNhc2wwmi8axl4NKWCQjBTtB7MAimSGHKxlv;SslMode=VerifyFull";

        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
