
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
                new TicketStatus{ Name = "New"},
                new TicketStatus { Name = "In progress"},
                new TicketStatus { Name = "Closed"}
                );

            context.Users.AddRange(
                new User {Name = "Bob" },
                new User {Name = "Sam" },
                new User {Name = "Jane" }
                );

            context.Projects.AddRange(
               new Project { Name = "Mega project" },
               new Project { Name = "Small project" },
               new Project { Name = "Secret project" }
               );

            context.SaveChanges();

            context.Tickets.AddRange(

                new Ticket
                {
                    ProjectId = 1 ,
                    Description = "Create DAL",
                    TicketStatusId = 2,
                    OpenedAt = (DateTime.UtcNow).AddDays(-1),
                    AuthorUserId = 1,
                },

                new Ticket
                {
                    ProjectId = 2,
                    Description = "Add controllers",
                    TicketStatusId = 1,
                    OpenedAt = (DateTime.UtcNow).AddHours(-1),
                    AuthorUserId = 2,
                },

                new Ticket
                {
                    ProjectId = 3,
                    Description = "Create DAL",
                    TicketStatusId = 3,
                    OpenedAt = (DateTime.UtcNow).AddDays(-2),
                    ClosedAt = DateTime.UtcNow,
                    AuthorUserId = 3,
                    ClosedByUserId = 1
                });


            context.SaveChanges();
        }

    }
}
