namespace QuestRoom.DomainModel
{
    public class QuestActor : BaseEntity
    {
        public int PersonalId { get; set; }

        public virtual Personal Personal { get; set; }

        public int QuestId { get; set; }

        public virtual Quest Quest { get; set; }
    }
}