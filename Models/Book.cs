using System.ComponentModel.DataAnnotations;

namespace crudLibrary.Models
    {
        
        public class Book
        {
            public int Id { get; set; }

            //  requiring a Title and setting a max char length to 60
            [Required]
            [MaxLength(60)]
            public string Title { get; set; }
            [MaxLength(60)]
            public string Author { get; set; }
            public string Description {get;set;}
            public decimal Price { get; set; }
            public bool IsAvailable { get; set; }

            public string CreatorEmail { get; set; }
        }

        public class BookGenreViewModel : Book
        {
            public int BookGenreId { get; set; }
            public string Genre { get; set; }
        }
    }