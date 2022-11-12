using Domain.Entities.v1;

namespace Domain.Interfaces.v1
{
    public interface IBooksOrderer
    {
        IEnumerable<Book> Order(IEnumerable<Book> books);
    }
}