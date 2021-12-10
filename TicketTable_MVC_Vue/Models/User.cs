namespace TicketTable_MVC_Vue.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }

        public string FullName { get
            {
                return $"{Surname} { Name} {Patronymic}";
            } }

        public virtual ICollection<Ticket> TicketsCreatedByUser { get; set; }
        public virtual ICollection<Ticket> TicketsClosedByUser { get; set; }

    }
}
