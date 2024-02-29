using Mission08_Team0309.Models;

namespace Mission08_Team0309
{
  public class EFToDoListRepository : IToDoListRepository
  {
    private ToDoListContext _context;
    public EFToDoListRepository(ToDoListContext temp)
    {
      _context = temp;
    }

        // public IQueryable<Item> Items => _context.Items.ToList();

        List<Item> IToDoListRepository.Items => _context.Items.ToList();

        // public void AddItem(Item item)
        // {
        //     throw new NotImplementedException();
        // }
    }
}