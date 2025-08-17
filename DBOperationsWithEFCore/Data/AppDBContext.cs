using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { CurrencyId = 1, Title = "INR", Description = "Indian Rupee" },
                new Currency() { CurrencyId = 2, Title = "Dollar", Description = "US Dollar" },
                new Currency() { CurrencyId = 3, Title = "Euro", Description = "Euro" },
                new Currency() { CurrencyId = 4, Title = "Diram", Description = "Arabic Diram" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { Id = 2, Title = "English", Description = "English" },
                new Language() { Id = 3, Title = "Bengali", Description = "Bengali" },
                new Language() { Id = 4, Title = "Punjabi", Description = "Punjabi" }
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
    }
}
