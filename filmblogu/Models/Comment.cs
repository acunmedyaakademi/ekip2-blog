using System.ComponentModel.DataAnnotations;

namespace filmblog.Models

{
    public class Comment
    {
        public int Id { get; set; }
        [Required]

        public int User_Id { get; set; }
        [Required]
        public int Film_Id { get; set; }
        public DateTime Date { get; set; }
        public bool Is_Active{ get; set; }
        [Required]

        public string TheComment{ get; set; }
    }
}
