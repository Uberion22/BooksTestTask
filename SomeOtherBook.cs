namespace BooksTestTask
{
    /// <summary>
    /// Просто пример класса наследника базового класса книги
    /// </summary>
    internal class SomeOtherBook: Book
    {
        public DateOnly PublicationDate { get; set; }
        public string Genre { get; set; }
        public SomeOtherBook(Guid id, string title, Content content, int pageCount)
            : base(id, title, content, pageCount)
        {}
    }
}
