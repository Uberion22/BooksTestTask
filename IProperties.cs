namespace BooksTestTask
{
    /// <summary>
    /// Интерфейс со свойствами объекта для испоьзования при различных расчетах.
    /// Можно использовать не только с книгой.
    /// </summary>
    internal interface IProperties
    {
        public float Height { get; set; }
        public float Mass { get; set; }
        public float Price { get; set; }
    }
}
