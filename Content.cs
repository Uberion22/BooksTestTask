namespace BooksTestTask
{
    /// <summary>
    /// Класс описывающий контент книги
    /// Сейчас это просто лист строк.
    /// </summary>
    internal class Content
    {
        public List<string> CurrentContent { get; set; }

        public Content(List<string> currentContent)
        {
            CurrentContent = currentContent;
        }

    }
}
