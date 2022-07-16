namespace BooksTestTask
{
    /// <summary>
    /// Основной менеджер управления каталогом(библиотекой): добавление, удаление поиск.
    /// За расположение книг принято расположение по первой букве фамилии автора.
    /// Поиск по фильтру не реализован.
    /// Так же содержит методы-заглушки покупки книги и испольщования стопки в качестве ножки стола.
    /// </summary>
    internal class BookManager
    {
        public Dictionary<char, List<Book>> Books { get; set; }
        private static readonly BookManager Instance = new BookManager();
        public static BookManager Current => Instance;
        private BookManager()
        {
            Books = new Dictionary<char, List<Book>>();
        }

        /// <summary>
        /// Добавить книгу на полку
        /// </summary>
        /// <param name="book">Добавляемая книга</param>
        public void AddBook(Book book)
        {
            var key = GetBookDictionaryKey(book);
            if (Books.ContainsKey(key))
            {
                Books[key].Add(book);
                return;
            }
            Books.Add(key, new List<Book>{book});
        }

        /// <summary>
        /// Искать книгу по первой букве фамилии автора(на определенной полке)
        /// </summary>
        /// <param name="key">Буква для поиска</param>
        /// <returns>Блок книг</returns>
        public BookPack GetBooksByKey(char key)
        {
            Books.TryGetValue(key, out var bookList);

            return new BookPack(bookList);
        }

        /// <summary>
        /// Получить книгу по id
        /// </summary>
        /// <param name="bookId">Id</param>
        /// <returns>Найденная книга</returns>
        public Book? GetBook(Guid bookId)
        {
            return Books.Values.SelectMany(bl => bl.Where(b => b.Id == bookId)).FirstOrDefault();
        }

        /// <summary>
        /// Удалить указанную книгу
        /// </summary>
        /// <param name="book">Книга</param>
        private void DeleteBook(Book book)
        {
            var key = GetBookDictionaryKey(book);
            if (Books.ContainsKey(key))
            {
                Books[key].Remove(book);
            }
        }

        /// <summary>
        /// Получить первую букву в фамилии автора книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <returns>Символ</returns>
        private char GetBookDictionaryKey(Book book)
        {
            return book.Authors.FirstOrDefault().LastName.FirstOrDefault(char.MinValue);
        }

        /// <summary>
        /// Установить статус(физическое состояние) книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="bookStatus">Новый статус</param>
        public void SetBookStatus(Book book, BookStatus bookStatus)
        {
            book.CurrentBookStatus = bookStatus;
        }

        /// <summary>
        /// Установить цену книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="price">Цена</param>
        private void SetBookPrice(IProperties book, float price)
        {
            book.Price = price;
        }

        /// <summary>
        /// Купить книгу
        /// </summary>
        /// <param name="book">Книга</param>
        public void ByBook(Book book)
        {
            //Здесь должын быть операции происходящие при покупке книги:
            //получение денег, перевод денег куда-либо, в конце которых книга покидает каталог
            DeleteBook(book);
        }

        /// <summary>
        /// Получить список книг со статусом Bad(под списание)
        /// </summary>
        /// <returns>"Упаковка" плохих книг</returns>
        public BookPack GetBadBooks()
        {
            var books = Books.Values.SelectMany(v => v.Where(b => b.CurrentBookStatus == BookStatus.Bad)).ToList();
            return new BookPack(books);
        }

        /// <summary>
        /// Получить ифнормацию из книги по заданной строке
        /// </summary>
        /// <param name="book">Книга для поиска</param>
        /// <param name="searchString">Строка для поиска</param>
        /// <returns>Найденные контент</returns>
        public Content GetContentInBook(ISearchable book, string searchString)
        {
            return book.SearchByString(searchString);
        }

        /// <summary>
        /// Получить массу стопки книг(для сдачи в мукулатуру)
        /// </summary>
        /// <param name="books">Список книг</param>
        /// <returns>Масса</returns>
        public float GetBooksMass(List<IProperties> books)
        {
            return books.Sum(b => b.Mass);
        }

        /// <summary>
        /// Получить высоту стопки книг(для установки вместо ножки стола)
        /// </summary>
        /// <param name="books">Список книг</param>
        /// <returns>Высота стопки</returns>
        public float GetBooksHeight(IUsableAsTableLeg books)
        {
            return books.Height;
        }
    }
}
