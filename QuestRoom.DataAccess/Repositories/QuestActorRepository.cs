using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestActorRepository : GenericRepository<QuestActor>, IQuestActorRepository
    {
        public QuestActorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
