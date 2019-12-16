using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translator.Client.Models
{
  public class UserViewModel
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int UserId{get; set;}
    [Required(ErrorMessage = "Please enter a Username.")] 
    public string Username { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please set a Password.")]
    [StringLength(25, MinimumLength = 8, ErrorMessage = "Please provide a longer password (max:100).")]
    public string Password { get; set; }
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Your passwords do not match.")]
    public string ConfirmPassword { get; set; }
    public string Language {get; set;}
    public DateTime CreatedAt { get; set; }
    public UserViewModel()
    {

    }
  }
}