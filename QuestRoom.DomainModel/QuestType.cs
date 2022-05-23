namespace QuestRoom.DomainModel
{
    public class QuestType : BaseEntity
    {
        public int TypeId { get; set; }

        public virtual QuestTypeName Type { get; set; }

        public int QuestRoomId { get; set; }

        public virtual Quest QuestRoom { get; set; }
    }
}