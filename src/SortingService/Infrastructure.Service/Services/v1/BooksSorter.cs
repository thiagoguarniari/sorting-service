using CrossCutting.Configuration.Settings;
using CrossCutting.CustomException;
using Domain.Entities.v1;
using Domain.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.v1
{
    public class BooksSorter : IBooksSorter
    {
        private readonly IConfiguration _configuration;
        private readonly SorterSettings _sorterSettings;

        public BooksSorter(IConfiguration configuration,
                            IOptions<SorterSettings> sorterSettings)
        {
            _configuration = configuration;
            _sorterSettings = sorterSettings.Value;
        }

        public IEnumerable<Book> Sort(IEnumerable<Book> books)
        {
            try
            {
                if (_sorterSettings.Title.Active)
                    books = OrderByTitle(books);

                if (_sorterSettings.AuthorName.Active)
                    books = OrderByAuthorName(books);

                if (_sorterSettings.EditionYear.Active)
                    books = OrderByEdition(books);

                return books;
            }
            catch
            {
                throw new SorterException();
            }
        }

        private IEnumerable<Book> OrderByTitle(IEnumerable<Book> books)
        {
            return _sorterSettings.Title.IsDescendingSort ? books.OrderByDescending(x => x.Title) : books.OrderBy(x => x.Title);
        }

        private IEnumerable<Book> OrderByAuthorName(IEnumerable<Book> books)
        {
            return _sorterSettings.AuthorName.IsDescendingSort ? books.OrderByDescending(x => x.AuthorName) : books.OrderBy(x => x.AuthorName);
        }

        private IEnumerable<Book> OrderByEdition(IEnumerable<Book> books)
        {
            return _sorterSettings.EditionYear.IsDescendingSort ? books.OrderByDescending(x => x.EditionYear) : books.OrderBy(x => x.EditionYear);
        }
    }
}