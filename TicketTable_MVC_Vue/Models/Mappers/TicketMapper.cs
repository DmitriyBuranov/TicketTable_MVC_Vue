using TicketTable_MVC_Vue.Models.Dto;

namespace TicketTable_MVC_Vue.Models.Mappers
{
    public class TicketMapper
    {
        public static Ticket MapFromModel(TicketDto request, Ticket? ticket = null)
        {
            if (ticket == null)
            {
                ticket = new Ticket();
                ticket.OpenedAt = DateTime.UtcNow;
            }

            ticket.ProjectId = request.ProjectId;
            ticket.Description = request.Description;
            ticket.TicketStatusId = request.TicketStatusId;
            ticket.ClosedAt = request.ClosedAt;
            ticket.AuthorUserId = request.AuthorUserId;
            ticket.ClosedByUserId = request.ClosedByUserId;
            return ticket;
        }

    }
}
