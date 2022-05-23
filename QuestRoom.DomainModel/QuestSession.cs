namespace QuestRoom.DomainModel
{
    public class QuestSession : BaseEntity
    {
        public DateTime StartedAt { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int QuestId { get; set; }

        public QuestRoom Quest { get; set; }
    }
}