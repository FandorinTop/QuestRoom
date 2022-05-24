using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
        public Task<Discount> FindByName(string name);
    }
}
