using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0309.Models
{
  public class ToDoListContext : DbContext
  {
    public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
    {

    }
  }
}