namespace BookShelf.UI.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string CoverImage { get; set; }
        public string Shelf { get; set; }
        public string Genre { get; set; }
        public bool Own { get; set; }
    }
}
