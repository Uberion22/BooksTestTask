namespace BooksTestTask
{
    /// <summary>
    /// Класс абстрактной книги содержащий в себе основные свойства для любой книги
    /// За контент отвечает отдельный класс, на данный момент просто содержащий лист строк.
    /// </summary>

    abstract class AbstractBook
    {
        public Guid Id { get;}
        public string Title { get;}
        public Content Content { get;}
        public int PageCount { get;}

        protected AbstractBook(Guid id, string title, Content content, int pageCount)
        {
            Id = id;
            Title = title;
            Content = content;
            PageCount = pageCount;
        }
    }
}
