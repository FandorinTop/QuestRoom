using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess.Repositories.Base;
using QuestRoom.DomainModel;
using QuestRoom.Interfaces.Repositories;

namespace QuestRoom.DataAccess.Repositories
{
    public class QuestActorRepository : GenericRepository<QuestActor>, IQuestActorRepository
    {
        public QuestActorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> CreateSingle(int personalId, int questId)
        {
            var questActor = await context.QuestActors.FirstOrDefaultAsync(item => item.PersonalId == personalId && item.QuestId == questId);

            if(questActor != null)
            {
                return questActor.Id;
            }
            else
            {
                var personal = await context.Personals.FindAsync(personalId);
                var actorSet = await context.Quests.FindAsync(questId);

                if (actorSet is null)
                {
                    throw new ServiceValidationException($"No ActorSet with id: '{personalId}'");
                }

                if (personal is null)
                {
                    throw new ServiceValidationException($"No Personal with id: '{personalId}'");
                }

                questActor = new QuestActor()
                {
                    PersonalId = personalId,
                    QuestId = questId,
                };

                await InsertAsync(questActor);
            }

            return questActor.Id;
        }
    }
}
