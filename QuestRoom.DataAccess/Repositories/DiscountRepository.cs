using Microsoft.EntityFrameworkCore;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Discount> FindByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(item => item.NormalizedName == name.ToUpperInvariant());
        }
    }
}
