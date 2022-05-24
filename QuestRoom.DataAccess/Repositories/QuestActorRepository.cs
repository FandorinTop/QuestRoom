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

        public async Task<int> CreateSingle(int personalId, int actorSetId)
        {
            var questActor = await context.QuestActors.FirstOrDefaultAsync(item => item.PersonalId == personalId && item.QuestActorSetId == actorSetId);

            if(questActor != null)
            {
                return questActor.Id;
            }
            else
            {
                var personal = await context.Personals.FindAsync(personalId);
                var actorSet = await context.ActorSets.FindAsync(actorSetId);

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
                    QuestActorSetId = actorSetId,
                };

                await InsertAsync(questActor);
            }

            return questActor.Id;
        }
    }
}
