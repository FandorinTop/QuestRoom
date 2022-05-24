using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IQuestActorRepository : IBaseRepository<QuestActor>
    {
        public Task<int> CreateSingle(int personalId, int actorSetId);
    }
}
