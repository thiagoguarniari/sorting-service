using CrossCutting.Configuration.Settings;
using CrossCutting.CustomException;
using Domain.Entities.v1;
using Domain.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.v1
{
    public class BooksOrderer : IBooksOrderer
    {
        private readonly IConfiguration _configuration;
        private readonly OrdererSettings _ordererSettings;

        public BooksOrderer(IConfiguration configuration,
                            IOptions<OrdererSettings> ordererSettings)
        {
            _configuration = configuration;
            _ordererSettings = ordererSettings.Value;
        }

        public IEnumerable<Book> Order(IEnumerable<Book> books)
        {
            try
            {
                if (_ordererSettings.Title.Active)
                    books = OrderByTitle(books);

                if (_ordererSettings.AuthorName.Active)
                    books = OrderByAuthorName(books);

                if (_ordererSettings.EditionYear.Active)
                    books = OrderByEdition(books);

                return books;
            }
            catch
            {
                throw new OrdererException();
            }
        }

        private IEnumerable<Book> OrderByTitle(IEnumerable<Book> books)
        {
            if (_ordererSettings.Title.IsDescendingSort)
                return books.OrderByDescending(x => x.Title);
            else
                return books.OrderBy(x => x.Title);
        }

        private IEnumerable<Book> OrderByAuthorName(IEnumerable<Book> books)
        {
            if (_ordererSettings.AuthorName.IsDescendingSort)
                return books.OrderByDescending(x => x.AuthorName);
            else
                return books.OrderBy(x => x.AuthorName);
        }

        private IEnumerable<Book> OrderByEdition(IEnumerable<Book> books)
        {
            if (_ordererSettings.EditionYear.IsDescendingSort)
                return books.OrderByDescending(x => x.EditionYear);
            else
                return books.OrderBy(x => x.EditionYear);
        }
    }
}