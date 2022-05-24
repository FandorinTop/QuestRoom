using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestRepository : GenericRepository<Quest>, IQuestRepository
    {
        public QuestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
