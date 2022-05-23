namespace QuestRoom.DomainModel
{
    public class QuestActorSet : BaseEntity
    {
        public int QuestId { get; set; }

        public virtual Quest Quest { get; set; }

        public virtual List<QuestActor> Actors { get; set; } = new List<QuestActor>();

        public virtual List<QuestSession> QuestSessions { get; set; } = new List<QuestSession>();
    }
}