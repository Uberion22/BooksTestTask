namespace BooksTestTask
{
    /// <summary>
    /// Интерфейс для обязательной реализации возможности поиска по контенту книг
    /// </summary>
    internal interface ISearchable
    {
        public Content SearchByString(string searchString);
    }
}