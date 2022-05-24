using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IQuestTypeRepository : IBaseRepository<QuestType>
    {
        public Task<int> CreateSingle(int questId, int questTypeNameId);
    }
}
