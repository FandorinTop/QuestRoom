using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestRepository : GenericRepository<Quest>, IQuestRepository
    {
        public QuestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
