using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{
    public class TypeRepository : GenericRepository<QuestTypeName>, IQuestTypeNameRepository
    {
        public TypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
