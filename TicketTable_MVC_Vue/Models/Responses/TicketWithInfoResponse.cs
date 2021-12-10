namespace TicketTable_MVC_Vue.Models.Responses
{
    public class TicketWithInfoResponse
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string TicketStatusName { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public string AuthorFullName { get; set; }
        public int AuthorUserId { get; set; }
        public string ClosedByFullName { get; set; }
        public int? ClosedByUserId { get; set; }

    }
}
