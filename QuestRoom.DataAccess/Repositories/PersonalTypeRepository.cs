using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class PersonalTypeRepository : GenericRepository<PersonalType>, IPersonalTypeRepository
    {
        public PersonalTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
