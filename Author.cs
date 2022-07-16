namespace BooksTestTask
{
    /// <summary>
    /// Класс описывающий автора книги как отдельный объект
    /// </summary>
    internal class Author
    {
        public Guid AuthorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly BirthDate { get; private set; }
    }
}
