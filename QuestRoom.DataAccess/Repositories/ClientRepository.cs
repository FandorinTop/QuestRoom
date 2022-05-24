using Microsoft.EntityFrameworkCore;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Client> FindByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(item => item.Name == name);
        }
    }
}
