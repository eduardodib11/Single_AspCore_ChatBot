using Microsoft.EntityFrameworkCore;

namespace chatbot.Models
{
    public class MemDbContext : DbContext
    {
        public MemDbContext(DbContextOptions<MemDbContext> options): base(options) {}
        public DbSet<cMessage> Messages {get;set;}
    }
}