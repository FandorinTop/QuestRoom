using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class TypeRepository : GenericRepository<QuestTypeName>, IQuestTypeNameRepository
    {
        public TypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
