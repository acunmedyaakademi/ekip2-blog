using filmblog.Models;
using filmblogu.Core;
using filmblogu.Models;
using System.Data.SqlClient;
using TestApp.Core;
using static BlogAppADO.Models.Dtos.UserDtos;

namespace BlogAppADO.DataAccess
{
    public class UserDal
    {
        public string connectionString = ConnectionString.ConnectionValue;

        CodeGenerator codeGenerator = new CodeGenerator();
        MailKitService mailKitService = new MailKitService();


        public List<User> GetAll()
        {
            var userList = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, rol_id, name, password, is_active, bio, profile_photo, mail, mail_sended_time, mail_code, mail_confirmed FROM users", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var userItem = new User();
                    userItem.Id = reader.GetInt32(0);
                    userItem.RolId = reader.GetInt32(1);
                    userItem.Name = reader.GetString(2);
                    userItem.Password = reader.GetString(3);
                    userItem.Is_Active = reader.GetBoolean(4);
                    userItem.Bio = reader.GetString(5);
                    userItem.Profil_Photo = reader.GetString(6);
                    userItem.Mail = reader.GetString(7);
                    userItem.Mail_Sended_Time = reader.GetDateTime(8);
                    userItem.Mail_Code = reader.GetString(9);
                    userItem.Mail_Confirmed = reader.GetBoolean(10);

                    userList.Add(userItem);
                }
            }
            return userList;
        }

        public User GetUserWithId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, rol_id, name, password, is_active, bio, profile_photo, mail, mail_sended_time, mail_code, mail_confirmed FROM users WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                reader.Read();

                var userItem = new User();
                userItem.Id = reader.GetInt32(0);
                userItem.RolId = reader.GetInt32(1);
                userItem.Name = reader.GetString(2);
                userItem.Password = reader.GetString(3);
                userItem.Is_Active = reader.GetBoolean(4);
                userItem.Bio = reader.GetString(5);
                userItem.Profil_Photo = reader.GetString(6);
                userItem.Mail = reader.GetString(7);
                userItem.Mail_Sended_Time = reader.GetDateTime(8);
                userItem.Mail_Code = reader.GetString(9);
                userItem.Mail_Confirmed = reader.GetBoolean(10);

                return userItem;
            }
        }

        public User GetUserWithEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, rol_id, name, password, is_active, bio, profile_photo, mail, mail_sended_time, mail_code, mail_confirmed FROM users WHERE mail = @email", connection);
                command.Parameters.AddWithValue("@email", email);
                var reader = command.ExecuteReader();
                reader.Read();

                var userItem = new User();
                userItem.Id = reader.GetInt32(0);
                userItem.RolId = reader.GetInt32(1);
                userItem.Name = reader.GetString(2);
                userItem.Password = reader.GetString(3);
                userItem.Is_Active = reader.GetBoolean(4);
                userItem.Bio = reader.GetString(5);
                userItem.Profil_Photo = reader.GetString(6);
                userItem.Mail = reader.GetString(7);
                userItem.Mail_Sended_Time = reader.GetDateTime(8);
                userItem.Mail_Code = reader.GetString(9);
                userItem.Mail_Confirmed = reader.GetBoolean(10);

                return userItem;
            }
        }

        public bool AddUser(AddUser user)
        {
            if (GetUserWithEmail(user.Mail) == null)
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        user.Mail_Code = codeGenerator.RandomPassword(6);
                        mailKitService.SendMailPassword(user.Mail, user.Mail_Code);
                        
                        connection.Open();

                        var command = new SqlCommand(
                           "INSERT INTO users (rol_id, name, password, is_active, bio, profile_photo, mail, mail_sended_time, mail_code)" +
                           "VALUES (@rolId, @name, @password, @is_Active, @bio, @profil_Photo, @mail, @mail_Sended_Time, @mail_Code)",
                                connection);

                        command.Parameters.AddWithValue("@rolId", user.RolId);
                        command.Parameters.AddWithValue("@name", user.Name);
                        command.Parameters.AddWithValue("@password", user.Password);
                        command.Parameters.AddWithValue("@bio", user.Bio);
                        command.Parameters.AddWithValue("@profil_Photo", user.Profil_Photo);
                        command.Parameters.AddWithValue("@mail", user.Mail);
                        command.Parameters.AddWithValue("@mail_Sended_Time", DateTime.Now);
                        command.Parameters.AddWithValue("@mail_Code", user.Mail_Code);

                        command.ExecuteNonQuery();

                        return true;

                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                }
            
            return false;
        }

        public bool UpdateUser(UpdateUser user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                            "UPDATE users SET name = @name, bio = @bio, profile_photo = @profil_Photo WHERE id = @id",
                            connection);

                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@name", user.Name);
                    //command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@bio", user.Bio);
                    command.Parameters.AddWithValue("@profil_Photo", user.Profil_Photo);
                    //command.Parameters.AddWithValue("@mail_Sended_Time", user.Mail_Sended_Time);
                    //command.Parameters.AddWithValue("@mail_Code", user.Mail_Code);
                    //command.Parameters.AddWithValue("@mail_Confirmed", user.Mail_Confirmed);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool UpdateUserPassword(UpdateUserPassword user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                            "UPDATE users SET password = @password WHERE id = @id and mail_code = @mail_Code",
                            connection);

                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@mail_Code", user.Mail_Code);
                    command.Parameters.AddWithValue("@password", user.Password);
                    //command.Parameters.AddWithValue("@mail_Sended_Time", user.Mail_Sended_Time);
                    //command.Parameters.AddWithValue("@mail_Confirmed", user.Mail_Confirmed);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool UpdateUserMailCode(UpdateUserMailCode user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                user.Mail_Code = codeGenerator.RandomPassword(6);

                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                            "UPDATE users SET mail_code = @mail_Code, mail_sended_time = @mail_Sended_Time WHERE id = @id",
                            connection);

                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@mail_Code", user.Mail_Code);
                    command.Parameters.AddWithValue("@mail_Sended_Time", DateTime.Now);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool DeleteUserWithId(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM users WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LoginUser Login(LoginModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    LoginUser userItem = new LoginUser();
                    connection.Open();
                    var command = new SqlCommand("SELECT id, mail_confirmed, name, mail, rol_id FROM Users WHERE mail = @email AND password = @password", connection);
                    command.Parameters.AddWithValue("@email", model.Email);
                    command.Parameters.AddWithValue("@password", model.Password);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        userItem.Id = reader.GetInt32(0);
                        userItem.MailConfirmed = reader.GetBoolean(1);
                        userItem.Name = reader.GetString(2);
                        userItem.Mail = reader.GetString(3);
                        userItem.RoleId = reader.GetInt32(4);

                        return userItem;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
