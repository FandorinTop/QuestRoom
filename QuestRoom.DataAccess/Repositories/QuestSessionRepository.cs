using Microsoft.EntityFrameworkCore;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestSessionRepository : GenericRepository<QuestSession>, IQuestSessionRepository
    {
        public QuestSessionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<QuestSession>> GetByTime(DateTime startedAt, int duration)
        {
            var before = startedAt.AddMinutes(duration);

            return await dbSet
                .Where(item => startedAt >= item.StartedAt && item.StartedAt <= before)
                .ToListAsync();
        }
    }
}
