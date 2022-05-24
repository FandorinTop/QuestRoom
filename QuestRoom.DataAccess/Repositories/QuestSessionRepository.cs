using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestSessionRepository : GenericRepository<QuestSession>, IQuestSessionRepository
    {
        public QuestSessionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
