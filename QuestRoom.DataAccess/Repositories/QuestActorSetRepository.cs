using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestActorSetRepository : GenericRepository<QuestActorSet>, IQuestActorSetRepository
    {
        public QuestActorSetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
