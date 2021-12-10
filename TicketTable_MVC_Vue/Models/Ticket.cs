namespace TicketTable_MVC_Vue.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public virtual User Author { get; set; }
        public int AuthorUserId { get; set; }
        public virtual User ClosedBy { get; set; }
        public int? ClosedByUserId { get; set; }


    }
}
