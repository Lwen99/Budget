using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Data
{
    public class ApplicationDbContext : DbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget.Models.Account> Account { get; set; } = default!;
    }
}
