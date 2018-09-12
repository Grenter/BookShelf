using System.Collections.Generic;

namespace BookShelf.Backend.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public bool Read { get; set; }
        public int YearRead { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}
