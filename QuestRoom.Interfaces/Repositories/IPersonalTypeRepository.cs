using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories.Base;

namespace QuestRoom.Interfaces.Repositories
{
    public interface IPersonalTypeRepository : IBaseRepository<PersonalType>
    {
        public Task<PersonalType> FindByName(string name);
    }
}
