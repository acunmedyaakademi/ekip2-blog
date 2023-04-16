using System.ComponentModel.DataAnnotations;

namespace filmblog.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(70)]
        public string Mail { get; set; }
        public DateTime Mail_Sended_Time { get; set; }
        [Required]
        public string Mail_Code { get; set; }
        public bool Mail_Confirmed { get; set; }
        [Required ]
        [MaxLength(50)]
        [MinLength(8)]
        public string Password { get; set; }

        public bool Is_Active { get; set; }

      
    }
}
