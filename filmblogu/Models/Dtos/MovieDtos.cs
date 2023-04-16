using System.ComponentModel.DataAnnotations;

namespace BlogAppADO.Models.Dtos
{
    public class MovieDtos
    {
        public class UpdateMovie
        {
            public int Id { get; set; }
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
            public string Picture { get; set; }
            [Required]
            public bool Is_Active { get; set; }
            public int? MovieMinute { get; set; }

        }

        public class AddMovie
        {
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
            public string Picture { get; set; }
            [Required]
            public bool Is_Active { get; set; }
            public int? MovieMinute { get; set; }
            public int UserID { get; set; }

        }
    }
}
