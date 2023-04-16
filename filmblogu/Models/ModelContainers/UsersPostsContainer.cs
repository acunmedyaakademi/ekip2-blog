using filmblog.Models;

namespace BlogAppADO.Models.ModelContainers
{
    public class UsersPostsContainer
    {

        public List<ConfirmModel> ConfirmModel { get; set; } = new List<ConfirmModel>();



    }

}

public class ConfirmModel 
{
    public string Mail { get; set; }
    public string MailCode { get; set; }
}

