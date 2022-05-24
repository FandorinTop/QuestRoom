using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDiscountRepository DiscountRepository { get; }
        public IPersonalRepository PersonalRepository { get; }
        public IPersonalTypeRepository PersonalTypeRepository { get; }
        public IQuestActorRepository QuestActorRepository { get; }
        public IQuestActorSetRepository QuestActorSetRepository { get; }
        public IQuestRepository QuestRepository { get; }
        public IQuestSessionRepository QuestSessionRepository { get; }
        public IQuestTypeRepository QuestTypeRepository { get; }
        public IQuestTypeNameRepository TypeRepository { get; }
    }
}
