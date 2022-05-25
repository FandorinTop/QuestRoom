using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDiscountRepository DiscountRepository { get; }
        public IPersonalRepository PersonalRepository { get; }
        public IPersonalTypeRepository PersonalTypeRepository { get; }
        public IQuestActorRepository QuestActorRepository { get; }
        public IQuestRepository QuestRepository { get; }
        public IQuestSessionRepository QuestSessionRepository { get; }
        public IQuestTypeNameRepository QuestTypeNameRepository { get; }
        public IClientRepository ClientRepository { get; }

        public Task SaveAsync();
    }
}
