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
      builder.Entity<User>(o => o.HasKey(k => k.Id));
      builder.Entity<User>().Property(p => p.Id).UseSerialColumn().ValueGeneratedOnAdd();

      builder.Entity<Message>(o => o.HasKey(k => k.Id));
      builder.Entity<Message>().Property(p => p.Id).UseSerialColumn().ValueGeneratedOnAdd();

      builder.Entity<User>().HasData(new List<User>()
      {
        new User(){ Id = 1, Username = "sergio", Password="12345678", Language="Spanish"},
        new User(){ Id = 2, Username = "john", Password="12345678", Language="English"},
        new User(){ Id = 3, Username = "herman", Password="12345678", Language="French"},
      });

      builder.Entity<Message>().HasData(new List<Message>()
      {
        new Message(){ Id = 1, UserId = 2, Content = "First Message", MessageDateTime = DateTime.Now},
        new Message(){ Id = 2, UserId = 3, Content = "Second Message", MessageDateTime = DateTime.Now},
        new Message(){ Id = 3, UserId = 2, Content = "Third Message", MessageDateTime = DateTime.Now}
      });


    }
  }
}