namespace BooksTestTask
{
    /// <summary>
    /// Класс книги содержащий в себе  свойства присущие  книге.
    /// Также реализован вариант поиска по контенту.
    /// За контент отвечает отдельный класс, на данный момент просто содержащий лист строк.
    /// </summary>
    internal class Book: ISearchable
    {
        public Guid Id { get; }
        public string Title { get; }
        public Content BookContent { get; }
        public int PageCount { get; }
        public BookStatus CurrentBookStatus { get; set; }
        public IProperties BookProperties { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }

        public Book(Guid id, string title, Content content, int pageCount)
        {
            Id = id;
            PageCount = pageCount;
            Description = "";
            Title = title;
            BookContent = content;
            Authors = new List<Author>();
            CurrentBookStatus = BookStatus.Good;
        }
        
        public Content SearchByString(string searchString)
        {
            return new Content(BookContent.CurrentContent.Where(c => c.Contains(searchString)).ToList());
        }
    }
}