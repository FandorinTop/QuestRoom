using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestActorRepository : GenericRepository<QuestActor>, IQuestActorRepository
    {
        public QuestActorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
