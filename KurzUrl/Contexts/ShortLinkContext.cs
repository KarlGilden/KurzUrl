using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KurzUrl.Contexts
{
    public class ShortLinkContext: DbContext
    {
        static readonly string connectionString = "Server=aws.connect.psdb.cloud;Database=kurz-link;user=5ss6yfq2ifk8m6ia6ou5;password=pscale_pw_5h0b4OYSEtf1A3GG0suq3jP0A3ZhvVDAfxdxc8pqp7O;SslMode=VerifyFull;";

        public DbSet<ShortLink> ShortLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
