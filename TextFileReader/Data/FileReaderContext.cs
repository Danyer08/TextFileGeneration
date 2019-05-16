using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TextFileReader.Data
{
    public sealed class FileReaderContext : DbContext
    {
        public DbSet<Archivo> Archivos { get; set; }

        public DbSet<DetalleArchivo> DetalleArchivos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build().GetConnectionString("Database");
        }
    }
}
