
namespace LibraryManagement.ConsoleUI.Models;

public abstract class Entity<TId>
{
    public Entity()
    {

    }
    protected Entity(TId id) : this() //Burası çalışırken boş constructor ilk olarak çalışsın.
    {
        Id = id;
    }

    public TId Id { get; set; }
}
