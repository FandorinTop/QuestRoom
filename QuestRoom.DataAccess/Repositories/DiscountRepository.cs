using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DataAccess.Repositories.Interfaces;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Repositories
{

    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
