using Microsoft.AspNetCore.Http.Features;
using Mission08_Team0309.Models;

namespace Mission08_Team0309
{
  public interface IToDoListRepository
  {
    
    List<Item> Items {get;}
    List<Category> Categories { get;}

    public void AddItem(Item item);

    public IQueryable<Item> UncompletedItems();

    public void UpdateItem(Item item);

    public void DeleteItem(Item item);
  }
}