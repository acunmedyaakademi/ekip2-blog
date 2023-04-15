namespace filmblogu.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUser
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public string? Mail { get; set; }
        public bool MailConfirmed { get; set; }

        public int RoleId { get; set; }

    }
}
