using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ApplicationDbContext:DbContext
    {
        // the context will be created through dependency injection
        // pass the db provider (mysql/sql server)
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        // setting db table column names used
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
