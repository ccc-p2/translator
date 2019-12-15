using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Translator.Storing.Models;

namespace Translator.Storing
{
  public class TranslatorDbContext : DbContext
  {
    public DbSet<User> User { get; set; }
    public DbSet<Message> Message { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
    {
      dbContext.UseNpgsql("server=localhost;database=postgres;user id=postgres;password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>(o => o.HasKey(k => k.UserId));
      builder.Entity<User>().Property(p => p.UserId).UseSerialColumn().ValueGeneratedOnAdd();

      builder.Entity<Message>(o => o.HasKey(k => k.MessageId));
      builder.Entity<Message>().Property(p => p.MessageId).UseSerialColumn().ValueGeneratedOnAdd();
      builder.Entity<Message>().HasOne(u => u.User).WithMany(m => m.Messages).HasForeignKey(m => m.UserId);

      builder.Entity<User>().HasData(new List<User>()
      {
        new User(){ UserId = 1, Username = "sergio", Password="12345678", Language="spanish"},
        new User(){ UserId = 2, Username = "john", Password="12345678", Language="english"},
        new User(){ UserId = 3, Username = "herman", Password="12345678", Language="french"},
      });

      builder.Entity<Message>().HasData(new List<Message>()
      {
        new Message(){ MessageId = 1, UserId = 2, Content = "first message", MessageDateTime = DateTime.Now},
        new Message(){ MessageId = 2, UserId = 2, Content = "second message", MessageDateTime = DateTime.Now},
        new Message(){ MessageId = 3, UserId = 3, Content = "third message", MessageDateTime = DateTime.Now}
      });


    }
  }
}