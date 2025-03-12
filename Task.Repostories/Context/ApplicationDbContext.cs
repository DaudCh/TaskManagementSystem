using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection.Emit;
using TaskI.Core.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

        if (!optionsBuilder.IsConfigured)

        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-4F8B9BO\\MSSQLSERVER01;Initial Catalog=TaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

    }


    public DbSet<User> Users { get; set; }
    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<TaskI.Core.Entities.Attachment> Attachments { get; set; }
    public DbSet<TaskAssignment> TaskAssignments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationRecipient> NotificationRecipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 🚀 Configure Task Assignment (Many-to-Many between User & Task)
        modelBuilder.Entity<TaskAssignment>()
            .HasOne(ta => ta.Task)
            .WithMany(t => t.TaskAssignments)
            .HasForeignKey(ta => ta.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TaskAssignment>()
            .HasOne(ta => ta.User)
            .WithMany(u => u.TaskAssignments)
            .HasForeignKey(ta => ta.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 🚀 Configure Task - User (Creator Relationship)
        modelBuilder.Entity<Tasks>()
            .HasOne(t => t.User)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict); // Prevent accidental task deletions if a user is removed

        // 🚀 Configure Attachment - Task Relationship
        modelBuilder.Entity<TaskI.Core.Entities.Attachment>()
            .HasOne(a => a.Task)
            .WithMany(t => t.Attachments)
            .HasForeignKey(a => a.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TaskI.Core.Entities.Attachment>()
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UploadedBy)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on attachments if user is deleted

        // 🚀 Configure Notification - Task Relationship
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.Task)
            .WithMany()
            .HasForeignKey(n => n.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany()
            .HasForeignKey(n => n.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        // 🚀 Configure NotificationRecipient - Notification Relationship
        modelBuilder.Entity<NotificationRecipient>()
            .HasOne(nr => nr.Notification)
            .WithMany(n => n.NotificationRecipients)
            .HasForeignKey(nr => nr.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NotificationRecipient>()
            .HasOne(nr => nr.User)
            .WithMany(u => u.NotificationRecipients)
            .HasForeignKey(nr => nr.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
