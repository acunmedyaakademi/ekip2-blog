
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;


namespace filmblog.Models
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public bool Is_Active { get; set; }
    }
}
