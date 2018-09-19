namespace BookShelf.Shared.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Shelf { get; set; }
        public bool Own { get; set; }
        public string Genre { get; set; }
        public int YearRead { get; set; }
        public string Format { get; set; }
        public string CoverImage { get; set; }
    }
}
