using Microsoft.EntityFrameworkCore;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quest> Quests { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Personal> Personals { get; set; }
    }
}