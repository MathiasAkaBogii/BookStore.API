namespace BookStore.API
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int Pages { get; set; } = 0;
        public double Rating { get; set; } = 0;
    }
}
