namespace crudLibrary.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }        
    }

    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}