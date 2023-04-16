using System.ComponentModel.DataAnnotations;

namespace BlogAppADO.Models.Dtos
{
    public class UserDtos
    {
        public class AddUser 
        {
            public int RolId { get; set; } = 1;
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
            [EmailAddress]
            [MaxLength(70)]
            public string Mail { get; set; }
            [Required]
            public string Mail_Code { get; set; }
            [Required]
            [MaxLength(50)]
            [MinLength(8)]
            public string Password { get; set; }
            [MaxLength(150)]
            public string Bio { get; set; }
            public string Profil_Photo { get; set; }
        }

        public class UpdateUser
        {
            public int Id { get; set; }
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
            [MaxLength(150)]
            public string Bio { get; set; }
            public string Profil_Photo { get; set; }
        }

        public class UpdateUserPassword
        {
            public int Id { get; set; }
            [Required]
            [MaxLength(50)]
            [MinLength(8)]
            public string Password { get; set; }
            [Required]
            public string Mail_Code { get; set; }
        }

        public class UpdateUserMailCode
        {
            public int Id { get; set; }
            [Required]
            public string Mail_Code { get; set; }
        }

        /*
        public class LoginUser
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Mail { get; set; }
            public bool MailConfirmed { get; set; }

            public int RoleId { get; set; }

        }*/
    }
}
