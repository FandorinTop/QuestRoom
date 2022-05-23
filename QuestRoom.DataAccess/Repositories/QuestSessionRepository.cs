using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestSessionRepository : GenericRepository<QuestSession>, IQuestSessionRepository
    {
        public QuestSessionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
