using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class DataContext: DbContext
    {
        static readonly string connectionString = "Server=aws.connect.psdb.cloud;Database=kurz-link;user=7gmpj1uzqiy8uuqabzlk;password=pscale_pw_AVEQdXeQCjYVtt34t6WYshXRNgKKkzo2CMknW57G0AT;SslMode=VerifyFull;";

        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
