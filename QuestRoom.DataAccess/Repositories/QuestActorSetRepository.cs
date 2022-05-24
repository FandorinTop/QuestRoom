using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestActorSetRepository : GenericRepository<QuestActorSet>, IQuestActorSetRepository
    {
        public QuestActorSetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
