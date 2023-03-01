using Microsoft.Data.SqlClient;
using MovieApp.Models;
using System.Collections.Immutable;
using System.Data;

namespace MovieApp.DAL
{
    public class MovieDataAccess
    {

        private const string connectionString = @"Server=localhost;database=A105Db;
                                                 Trusted_Connection=true;
                                                 TrustServerCertificate=true;";
        public IReadOnlyList<Movie> GetsAllMovies() 
        {

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM movie"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    var movies = dt.AsEnumerable()
                                    .Select(f => new Movie
                                    {
                                        Id = f.Field<int>("id"),
                                        Description = f.Field<string>("description"),
                                        Title = f.Field<string>("Title") ?? "",
                                        ReleaseDate = f.Field<DateTime>("ReleaseDate"),
                                        Genre = (Genre)f.Field<Genre>("Genre")

                                    }).ToList();
                    return movies;

                }

            }
        }


        public DataTable GetsAllMoviesAsDt() 
        {

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM movie"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }

            }
        }
        public bool CreateMovie(Movie movie)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(@"INSERT INTO movie(title,description,genre,releaseDate) 
                                                     VALUES(@0,@1,@2,@3)"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@0", movie.Title);
                    cmd.Parameters.AddWithValue("@1", movie.Description);
                    cmd.Parameters.AddWithValue("@2", movie.Genre);
                    cmd.Parameters.AddWithValue("@3", movie.ReleaseDate);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Movie GetAMovie(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(@"SELECT * FROM movie WHERE id=@0;"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@0",id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    var movie = dt.AsEnumerable()
                                    .Select(f => new Movie
                                    {
                                        Id = f.Field<int>("id"),
                                        Description = f.Field<string>("description"),
                                        Title = f.Field<string>("Title") ?? "",
                                        ReleaseDate = f.Field<DateTime>("ReleaseDate"),
                                        Genre = (Genre)f.Field<Genre>("Genre")

                                    }).FirstOrDefault();
                    return movie??default!;
                }
            }
        }


        public bool UpdateMovie(Movie movie) 
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(@"UPDATE movie SET title=@1,description=@2,
                                                    genre=@3,releaseDate=@4 WHERE id=@0"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@0", movie.Id); 
                    cmd.Parameters.AddWithValue("@1", movie.Title);
                    cmd.Parameters.AddWithValue("@2", movie.Description);
                    cmd.Parameters.AddWithValue("@3", movie.Genre);
                    cmd.Parameters.AddWithValue("@4", movie.ReleaseDate);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool DeleteAMovie(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(@"DELETE FROM movie WHERE id=@0;"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@0", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
