using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestTypeRepository : GenericRepository<QuestType>, IQuestTypeRepository
    {
        public QuestTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
