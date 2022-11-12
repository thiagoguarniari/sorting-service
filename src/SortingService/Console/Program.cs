using CrossCutting.Configuration.Settings;
using Domain.Entities.v1;
using Domain.Interfaces.v1;
using Infrastructure.Services.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

Console.WriteLine("Configurating Dependency Injection");

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

serviceCollection.AddScoped<IBooksOrderer, BooksOrderer>();
serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.Configure<OrdererSettings>(configuration.GetSection("OrdererSettings"));

var serviceProvider = serviceCollection.BuildServiceProvider();

var orderer = serviceProvider.GetRequiredService<IBooksOrderer>();

var books = new List<Book> {
    new Book("Java How to Program", "Deitel & Deitel", 2007),
    new Book("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
    new Book("Head First Design Patterns", "Elisabeth Freeman", 2004),
    new Book("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007),
};

try
{
    var orderedBooks = orderer.Order(books);
    Console.WriteLine("Ordered Books");

    foreach (var book in orderedBooks)
        Console.WriteLine($"Title: {book.Title} - Author Name: {book.AuthorName} - Edition Year: {book.EditionYear}");
}
catch (Exception e)
{
    Console.WriteLine($"[Error]: {e}");
}

Console.WriteLine("Service Finished");