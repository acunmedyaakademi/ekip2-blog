using System.ComponentModel.DataAnnotations;

namespace filmblog.Models
{
    public class Movie
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string MovieName { get; set; }
        [Required]
        [MaxLength(70)]
        public string Director { get; set; }
        [MaxLength(150)]
        public string Summary { get; set; }
        [MaxLength(50)]
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }
        public string Updated_On { get; set; }
        public string Create_On { get; set; }
        public string Picture { get; set; }
        [Required]
        public bool Is_Active { get; set; }


    }
    
}
