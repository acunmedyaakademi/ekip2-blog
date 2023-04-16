using filmblog.Models;
using System.Data.SqlClient;
using System.Reflection;
using static BlogAppADO.Models.Dtos.MovieDtos;

namespace BlogAppADO.DataAccess
{
    public class MovieDal
    {
        public string connectionString = ConnectionString.ConnectionValue;

        public List<Movie> GetAll()
        {
            var movieList = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, movie_name, director, summary, slug, content, created_on, updated_on, picture, is_active, movie_minute, user_id FROM movies ORDER BY created_on DESC", connection);
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var movieItem = new Movie();
                    movieItem.Id = reader.GetInt32(0);
                    movieItem.MovieName = reader.GetString(1);
                    movieItem.Director = reader.GetString(2);
                    movieItem.Summary = reader.GetString(3);
                    movieItem.Slug = reader.GetString(4);
                    movieItem.Content = reader.GetString(5);
                    movieItem.Create_On = reader.GetDateTime(6);
                    movieItem.Updated_On = reader.GetDateTime(7);
                    movieItem.Picture = reader.GetString(8);
                    movieItem.Is_Active = reader.GetBoolean(9);
                    movieItem.MovieMinute = reader.GetInt32(10);
                    movieItem.UserID = reader.GetInt32(11);

                    movieList.Add(movieItem);
                }
            }
            return movieList;
        }

        public Movie GetPostWithId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, movie_name, director, summary, slug, content, created_on, updated_on, picture, is_active, movie_minute, user_id FROM movies WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                reader.Read();
                var movieItem = new Movie();
                movieItem.Id = reader.GetInt32(0);
                movieItem.MovieName = reader.GetString(1);
                movieItem.Director = reader.GetString(2);
                movieItem.Summary = reader.GetString(3);
                movieItem.Slug = reader.GetString(4);
                movieItem.Content = reader.GetString(5);
                movieItem.Create_On = reader.GetDateTime(6);
                movieItem.Updated_On = reader.GetDateTime(7);
                movieItem.Picture = reader.GetString(8);
                movieItem.Is_Active = reader.GetBoolean(9);
                movieItem.MovieMinute = reader.GetInt32(10);
                movieItem.UserID = reader.GetInt32(11);

                return movieItem;
            }
        }

        public List<Movie> GetPostWithUserId(int userID)
        {
            var movieList = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, movie_name, director, summary, slug, content, created_on, updated_on, picture, is_active, movie_minute, user_id FROM movies WHERE user_id = @userID", connection);
                command.Parameters.AddWithValue("@userID", userID);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var movieItem = new Movie();
                    movieItem.Id = reader.GetInt32(0);
                    movieItem.MovieName = reader.GetString(1);
                    movieItem.Director = reader.GetString(2);
                    movieItem.Summary = reader.GetString(3);
                    movieItem.Slug = reader.GetString(4);
                    movieItem.Content = reader.GetString(5);
                    movieItem.Create_On = reader.GetDateTime(6);
                    movieItem.Updated_On = reader.GetDateTime(7);
                    movieItem.Picture = reader.GetString(8);
                    movieItem.Is_Active = reader.GetBoolean(9);
                    movieItem.MovieMinute = reader.GetInt32(10);
                    movieItem.UserID = reader.GetInt32(11);

                    movieList.Add(movieItem);
                }
            }
            return movieList;
        }

        public Movie GetPostWithSlug(string slug)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT id, movie_name, director, summary, slug, content, created_on, updated_on, picture, is_active, movie_minute, user_id FROM movies WHERE slug = @slug", connection);
                command.Parameters.AddWithValue("@slug", slug);
                var reader = command.ExecuteReader();
                reader.Read();
                var movieItem = new Movie();
                movieItem.Id = reader.GetInt32(0);
                movieItem.MovieName = reader.GetString(1);
                movieItem.Director = reader.GetString(2);
                movieItem.Summary = reader.GetString(3);
                movieItem.Slug = reader.GetString(4);
                movieItem.Content = reader.GetString(5);
                movieItem.Create_On = reader.GetDateTime(6);
                movieItem.Updated_On = reader.GetDateTime(7);
                movieItem.Picture = reader.GetString(8);
                movieItem.Is_Active = reader.GetBoolean(9);
                movieItem.MovieMinute = reader.GetInt32(10);
                movieItem.UserID = reader.GetInt32(11);

                return movieItem;
            }
        }

        public bool UpdatePost(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                            "UPDATE movies SET movie_name = @movieName, director = @director, summary = @summary, slug = @slug, content = @content, updated_on = @updatedOn, picture = @picture, is_active = @is_Active, movie_minute = @movieMinute WHERE id = @id",
                            connection);

                    command.Parameters.AddWithValue("@id", movie.Id);
                    command.Parameters.AddWithValue("@movieName", movie.MovieName);
                    command.Parameters.AddWithValue("@director", movie.Director);
                    command.Parameters.AddWithValue("@summary", movie.Summary);
                    command.Parameters.AddWithValue("@slug", movie.Slug);
                    command.Parameters.AddWithValue("@content", movie.Content);
                    command.Parameters.AddWithValue("@updatedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@picture", movie.Picture);
                    command.Parameters.AddWithValue("@is_Active", movie.Is_Active);
                    command.Parameters.AddWithValue("@movieMinute", movie.MovieMinute);
                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool AddPost(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand(
                        "INSERT INTO movies (movie_name, director, summary, slug, content, created_on, updated_on, picture, is_active, movie_minute, user_id) VALUES (@movieName, @director, @summary, @slug, @content, @createdOn, @updatedOn, @picture, @is_Active, @movieMinute, @userID)",
                            connection);

                    command.Parameters.AddWithValue("@movieName", movie.MovieName);
                    command.Parameters.AddWithValue("@director", movie.Director);
                    command.Parameters.AddWithValue("@summary", movie.Summary);
                    command.Parameters.AddWithValue("@slug", movie.Slug);
                    command.Parameters.AddWithValue("@content", movie.Content);
                    command.Parameters.AddWithValue("@createdOn", DateTime.Now);
                    command.Parameters.AddWithValue("@updatedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@picture", movie.Picture);
                    command.Parameters.AddWithValue("@is_Active", movie.Is_Active);
                    command.Parameters.AddWithValue("@movieMinute", movie.MovieMinute);
                    command.Parameters.AddWithValue("@userID", movie.UserID);

                    command.ExecuteNonQuery();

                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public bool DeletePostWithId(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM movies WHERE id = @id", connection);
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
    }
}