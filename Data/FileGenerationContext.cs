using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TextFileGeneration.Entities;

namespace TextFileGeneration.Data
{
    /// <summary>
    /// Represents the context to connect with database
    /// </summary>
    public class FileGenerationContext : DbContext
    {
        private IConfiguration Configuration { get; set; }

        /// <summary>
        /// Initialize a new instance of DataContext
        /// </summary>
        /// <param name="options">An instance of <see cref="DbContextOptions"/></param>
        public FileGenerationContext(DbContextOptions options) : base(options) { }

        public FileGenerationContext()
        {
        }

        internal DbSet<Institution> Institutions { get; set; }

        internal DbSet<Employee> Employees { get; set; }

        internal DbSet<HardwareStore> HardwareStores { get; set; }

        internal DbSet<HardwareStoreEmployee> HardwareStoreEmployees { get; set; }

        internal DbSet<InterExchange> InterExchanges { get; set; }

        internal DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("Database");
        }
    }
}
