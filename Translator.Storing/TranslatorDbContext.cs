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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("server=localhost;database=postgres;user id=postgres;password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
      modelbuilder.HasSequence<int>("UserId").StartsAt(10).IncrementsBy(1);
      modelbuilder.Entity<User>(o => o.HasKey(k => k.UserId));
      modelbuilder.Entity<User>().Property(p => p.UserId).HasDefaultValueSql("nextval('\"UserId\"')");

      modelbuilder.HasSequence<int>("MessageId").StartsAt(100).IncrementsBy(2);
      modelbuilder.Entity<Message>(o => o.HasKey(k => k.MessageId));
      modelbuilder.Entity<Message>().Property(p => p.MessageId).HasDefaultValueSql("nextval('\"MessageId\"')");
      modelbuilder.Entity<Message>().HasOne(u => u.User).WithMany(m => m.Messages).HasForeignKey(m => m.UserId);

      modelbuilder.Entity<User>().HasData(new List<User>()
      {
        new User(){ UserId = 1, Username = "sergio", Password="12345678", Language="spanish"},
        new User(){ UserId = 2, Username = "john", Password="12345678", Language="english"},
        new User(){ UserId = 3, Username = "herman", Password="12345678", Language="french"},
      });

      modelbuilder.Entity<Message>().HasData(new List<Message>()
      {
        new Message(){ MessageId = 1, UserId = 2, Content = "first message", MessageDateTime = DateTime.Now},
        new Message(){ MessageId = 2, UserId = 2, Content = "second message", MessageDateTime = DateTime.Now},
        new Message(){ MessageId = 3, UserId = 3, Content = "third message", MessageDateTime = DateTime.Now}
      });

    }
  }
}