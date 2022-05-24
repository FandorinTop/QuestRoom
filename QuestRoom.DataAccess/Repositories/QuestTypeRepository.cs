using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestTypeRepository : GenericRepository<QuestType>, IQuestTypeRepository
    {
        public QuestTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> CreateSingle(int questlId, int questTypeNameId)
        {
            var questTypes = await context.QuestTypes.FirstOrDefaultAsync(item => item.QuestRoomId == questlId && item.TypeId == questTypeNameId);

            if (questTypes != null)
            {
                return questTypes.Id;
            }
            else
            {
                var personal = await context.Quests.FindAsync(questlId);
                var actorSet = await context.QuestTypeNames.FindAsync(questTypeNameId);

                if (actorSet is null)
                {
                    throw new ServiceValidationException($"No ActorSet with id: '{questlId}'");
                }

                if (personal is null)
                {
                    throw new ServiceValidationException($"No Personal with id: '{questlId}'");
                }

                questTypes = new QuestType()
                {
                    QuestRoomId = questlId,
                    TypeId = questTypeNameId,
                };

                await InsertAsync(questTypes);
            }

            return questTypes.Id;
        }
    }
}
