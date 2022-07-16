namespace BooksTestTask
{
    /// <summary>
    /// Класс реализует Инерфейс свойств
    /// </summary>
    internal class Properties: IProperties
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public float Mass { get; set; }
        public float Price { get; set; }
    }
}
