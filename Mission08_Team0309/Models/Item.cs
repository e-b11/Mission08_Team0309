using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0309
{
  public class Item
  {
    [Key]
    public required int Id {get; set;}
    public required string Task {get; set;}
    public DateTime? DueDate {get; set;}
    public required int Quadrant {get; set;}
    [ForeignKey("CategoryId")]
    public int? CategoryId {get; set;}
    public bool Completed {get; set;} = false;
  }
}