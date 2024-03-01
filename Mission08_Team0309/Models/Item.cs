using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mission08_Team0309.Models;

namespace Mission08_Team0309
{
  public class Item
  {
    [Key]
    public required int Id {get; set;}

    [Required(ErrorMessage = "Please Enter a Task")]
    public required string Task {get; set;}
    public DateTime? DueDate {get; set;}

    [Required(ErrorMessage = "Please Enter a Quadrant")]
    public required int Quadrant {get; set;}
    [ForeignKey("CategoryId")]
    public Category? Category {get; set;}
    public int? CategoryId {get; set;}
    public bool Completed {get; set;} = false;
  }
}