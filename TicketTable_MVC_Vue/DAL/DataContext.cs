
using Microsoft.EntityFrameworkCore;
using TicketTable_MVC_Vue.Models;

namespace TicketTable_MVC_Vue.DAL
{
    public class DataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<Project> Prokects { get; set; }

        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }
        

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureDeleted(); 
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity => 
            {
                entity.HasOne(d => d.Author)
                  .WithMany(p => p.TicketsCreatedByUser)
                  .HasForeignKey(d => d.AuthorUserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Tickets_Author");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(d => d.ClosedBy)
                  .WithMany(p => p.TicketsClosedByUser)
                  .HasForeignKey(d => d.ClosedByUserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Tickets_ClosedBy");
            });
        }
    }
}
