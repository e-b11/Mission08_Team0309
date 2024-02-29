using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0309.Models
{
  public class Category
  {
    [Key]
    public required int CategoryId {get; set;}
    public required string CategoryName {get; set;}
  }
}