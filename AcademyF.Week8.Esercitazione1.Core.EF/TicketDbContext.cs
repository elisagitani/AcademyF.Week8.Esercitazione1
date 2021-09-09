using AcademyF.Week8.Esercitazione1.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.EF
{
    public class TicketDbContext: DbContext
    {

        public TicketDbContext(DbContextOptions<TicketDbContext> options)
            : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TICKET
            var ticketModel = modelBuilder.Entity<Ticket>();

            ticketModel.HasKey(t => t.Id);

            ticketModel.Property(t => t.CreationDate)
                .IsRequired();

            ticketModel.Property(t => t.Applicant)
                .IsRequired()
                .HasMaxLength(50);

            ticketModel.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            ticketModel.Property(t => t.Description);

            ticketModel.Property(t => t.ClosingDate);

            ticketModel.Property(t => t.CategoryId)
                .IsRequired();

            ticketModel.Property(t => t.TicketManager)
               .HasMaxLength(50);

            ticketModel.Property(t => t.Priority)
                .IsRequired()
                .HasConversion<string>();

            ticketModel.Property(t => t.State)
                    .IsRequired()
                    .HasConversion<string>();
            #endregion

            #region NOTE
            var noteModel = modelBuilder.Entity<Note>();
            noteModel.HasKey(n => n.Id);

            noteModel.Property(n=>n.CreationDate)
                .IsRequired();

            noteModel.Property(n=>n.Text)
                .IsRequired();

            noteModel.Property(n => n.TicketId)
                .IsRequired();
            #endregion

            #region CATEGORY
            var categoryModel = modelBuilder.Entity<Category>();
            categoryModel.HasKey(c => c.Id);

            categoryModel.Property(n => n.Name)
                .IsRequired();

            categoryModel.Property(n => n.Code)
                .IsRequired()
                .HasMaxLength(20);

            #endregion

        }
    }
}
