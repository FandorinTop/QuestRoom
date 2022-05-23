using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestTypeRepository : GenericRepository<QuestType>, IQuestTypeRepository
    {
        public QuestTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
