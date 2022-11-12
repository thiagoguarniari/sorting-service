using Domain.Entities.v1;

namespace Domain.Interfaces.v1
{
    public interface IBooksSorter
    {
        IEnumerable<Book> Sort(IEnumerable<Book> books);
    }
}