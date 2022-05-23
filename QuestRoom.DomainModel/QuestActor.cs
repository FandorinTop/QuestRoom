namespace QuestRoom.DomainModel
{
    public class QuestActor : BaseEntity
    {
        public int PersonalId { get; set; }

        public virtual Personal Personal { get; set; }

        public int QuestActorSetId { get; set; }

        public virtual QuestActorSet QuestActorSet { get; set; }
    }
}