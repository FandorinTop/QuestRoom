using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class PersonalRepository : GenericRepository<Personal>, IPersonalRepository
    {
        public PersonalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
