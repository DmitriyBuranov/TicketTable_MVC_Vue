
using TicketTable_MVC_Vue.Models;

namespace TicketTable_MVC_Vue.DAL
{
    public class DbInitializer : IDbInitializer
    {
         private readonly DataContext context;

        public DbInitializer(DataContext dataContext)
        {
            context = dataContext;
        }

        public void InitializeDb()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.TicketStatuses.Any())
            {
                return;
            }

            context.TicketStatuses.AddRange(
                new TicketStatus{ Id = 1,Name = "New"},
                new TicketStatus { Id = 2, Name = "In progress"},
                new TicketStatus { Id = 3, Name = "Closed"}
                );

            context.Users.AddRange(
                new User { Id = 1, Name = "Bob" },
                new User { Id = 2, Name = "Sam" },
                new User { Id = 3, Name = "Jane" }
                );


            context.SaveChanges();
        }

    }
}
