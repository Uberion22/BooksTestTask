namespace BooksTestTask
{
    /// <summary>
    /// Класс стопки книг(реализует IUsableAsTableLeg: возможность использования в качестве ножки стола)
    /// </summary>
    internal class BookPack : IUsableAsTableLeg
    {
        public List<Book>? Books { get; }
        public float Height { get; }

        public BookPack(List<Book>? books)
        {
            Books = books;
            if (books != null)
            {
                Height = books.Sum(b => b.BookProperties.Height);
            }
        }
    }
}
