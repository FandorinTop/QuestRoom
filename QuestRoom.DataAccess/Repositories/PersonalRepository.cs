using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class PersonalRepository : GenericRepository<Personal>, IPersonalRepository
    {
        public PersonalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
