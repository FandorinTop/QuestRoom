using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IQuestSessionRepository : IBaseRepository<QuestSession>
    {
        public Task<List<QuestSession>> GetByTime(DateTime startedAt, int duration);
    }
}
