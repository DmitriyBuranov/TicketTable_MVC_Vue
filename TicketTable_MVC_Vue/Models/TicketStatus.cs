namespace TicketTable_MVC_Vue.Models
{
    public class TicketStatus 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
