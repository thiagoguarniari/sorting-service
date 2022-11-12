namespace Domain.Entities.v1
{
    public class Book
    {
        public Book(string title, string authorName, int editionYear)
        {
            Title = title;
            AuthorName = authorName;
            EditionYear = editionYear;
        }

        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int EditionYear { get; set; }
    }
}