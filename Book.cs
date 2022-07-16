namespace BooksTestTask
{
    /// <summary>
    /// Класс книги содержащий в себе расширенные
    /// свойства(присущие не каждой книге)
    /// Также реализован вариант поиска по контенту в книге
    /// </summary>
    internal class Book: AbstractBook, IProperties, ISearchable
    {
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public BookStatus BookStatus { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public float Mass { get; set; }
        public float Price { get; set; }

        public Book(Guid id, string title, Content content, int pageCount, string description) 
            : base(id, title, content, pageCount)
        {
            Description = description;
            Authors = new List<Author>();
            BookStatus = BookStatus.Good;
        }
        
        public Content SearchInContent(string searchString)
        {
            return new Content(Content.CurrentContent.Where(c => c.Contains(searchString)).ToList());
        }
    }
}