namespace TicketTable_MVC_Vue.Models.Dto
{
    public class TicketDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public int AuthorUserId { get; set; }
        public int ClosedByUserId { get; set; }
    }
}
