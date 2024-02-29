using Microsoft.AspNetCore.Http.Features;
using Mission08_Team0309.Models;

namespace Mission08_Team0309
{
  public interface IToDoListRepository
  {
    
    List<Item> Items {get;}

    // public void AddItem(Item item);
  }
}