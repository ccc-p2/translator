using System.Collections.Generic;
using System.Linq;
using Translator.Storing.Models;

namespace Translator.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly TranslatorDbContext _db = new TranslatorDbContext();

    public User GetUser(int userId)
    {
      return _db.User.FirstOrDefault(u => u.UserId == userId);
    }
    public List<User> GetAllUsers()
    {
      return _db.User.ToList();
    } 
  }
}