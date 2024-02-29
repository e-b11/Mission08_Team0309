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

        public void AddItem(Item item)
        {
            _context.Add(item);
            
            _context.SaveChanges();
        }

        public IQueryable<Item> UncompletedItems()
        {
          IQueryable<Item> items = _context.Items.Where(i => i.Completed == false);
          return items;
        }

        public void UpdateItem(Item item)
        {
          _context.Update(item);

          _context.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
          _context.Items.Remove(item);

          _context.SaveChanges();
        }
    }
}