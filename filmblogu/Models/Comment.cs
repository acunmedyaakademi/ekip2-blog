using System.ComponentModel.DataAnnotations;

namespace filmblog.Models

{
    public class Comment
    {
        public int? Id { get; set; }
        [Required]

        public int UserId { get; set; }
        [Required]
        public int FilmId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        [Required]

        public string TheComment{ get; set; }

        public string? name { get; set; }

        public string? MovieName  { get; set; }

    }

}
