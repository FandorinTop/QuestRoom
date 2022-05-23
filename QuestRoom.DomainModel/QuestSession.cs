namespace QuestRoom.DomainModel
{
    public class QuestSession : BaseEntity
    {
        public DateTime StartedAt { get; set; }

        public int ParticipantCount { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int QuestActorSetId { get; set; }

        public virtual QuestActorSet QuestActorSet { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
    }
}