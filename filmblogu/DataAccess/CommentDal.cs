using filmblog.Models;
using System.Data.SqlClient;

namespace BlogAppADO.DataAccess
{
    public class CommentDal
    {
        public string connectionString = ConnectionString.ConnectionValue;

        public List<Comment> GetComments(int a)
        {
            var commentList = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("select c.id, comment, date, c.user_id, c.film_id, name, m.movie_name from comments as c join users as u on c.user_id = u.id join movies as m on c.film_id = m.id where c.film_id = @film_id and c.is_active = 1", connection);

                command.Parameters.AddWithValue("@film_id", a);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var commentItem = new Comment();
                    commentItem.Id = reader.GetInt32(0);
                    commentItem.TheComment = reader.GetString(1);
                    commentItem.Date = reader.GetDateTime(2);
                    commentItem.UserId = reader.GetInt32(3);
                    commentItem.FilmId = reader.GetInt32(4);
                    commentItem.name= reader.GetString(5);
                    commentItem.MovieName = reader.GetString(6);

                    commentList.Add(commentItem);
                }
            }
            return commentList;
        }

        public List<Comment> GetCommentsUnAccepted()
        {
            var commentList = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("select c.id, comment, date, c.user_id, c.film_id, name, m.movie_name from comments as c join users as u on c.user_id = u.id join movies as m on c.film_id = m.id where c.is_active = 0", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var commentItem = new Comment();
                    commentItem.Id = reader.GetInt32(0);
                    commentItem.TheComment = reader.GetString(1);
                    commentItem.Date = reader.GetDateTime(2);
                    commentItem.UserId = reader.GetInt32(3);
                    commentItem.FilmId = reader.GetInt32(4);
                    commentItem.name = reader.GetString(5);
                    commentItem.MovieName = reader.GetString(6);

                    commentList.Add(commentItem);
                }
            }
            return commentList;
        }


        public bool AddComment(Comment comment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                            "INSERT INTO [comments] (comment, date, user_id, film_id, is_active) VALUES (@Comment, @date, @UserId, @FilmId, @IsActive)",
                            connection);

                    command.Parameters.AddWithValue("@Comment", comment.TheComment);
                    command.Parameters.AddWithValue("@IsActive", comment.IsActive);
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@UserId", comment.UserId);
                    command.Parameters.AddWithValue("@FilmId", comment.FilmId);

                    command.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool AcceptComment(int a)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand("Update comments set is_active = 1 where id = @Id",  connection);

                    command.Parameters.AddWithValue("@Id", a);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch
                {
                    return false;
                }

            }
        }

        public bool DeleteComment(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Comments WHERE ID = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
