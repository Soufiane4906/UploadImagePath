using System.ComponentModel.DataAnnotations.Schema;

namespace FilmImageScaf.Models
{
    public class ModelTest
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set; } 

    }
}
