using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using movieReviewAPI.Models;

namespace movieReviewAPI.Services
{
    public class MovieDAO
    {

        public static DataTable Get()
        {
            SqlConnection db = new SqlConnection();
            var con = new SqlConnection(ConfigurationManager.
             ConnectionStrings["MovieReviewDB"].ConnectionString);
            SqlCommand s = new SqlCommand("select MovieId,MovieName,MovieDirector,MovieDescription,MoviePhoto,ReviewAverage from dbo.Movie", con);
            string movieDB = "dbo.Movie";
            string query = @"SELECT
m.MovieId,
m.MovieName,
m.MovieDirector,
m.MovieDescription,
m.MoviePhoto,
isnull(AVG(r.Rating),0) AS ReviewAverage
FROM
dbo.Movie AS m
LEFT OUTER JOIN
dbo.Review AS r
ON r.MovieId = m.MovieId
GROUP BY
m.MovieId,
m.MovieName,
m.MovieDirector,
m.MovieDescription,
m.MoviePhoto
ORDER BY
m.MovieName";



            string query2 = @"select MovieId,MovieName,MovieDirector,MovieDescription, MoviePhoto from 
            dbo.Movie
                            ";



            var command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@dbo.Movie", movieDB);

            s.Prepare();

            DataTable table = new DataTable();

            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }

        public static DataTable GetById(int id)
        {
            
            string query = @"select MovieId,MovieName,MovieDirector,MovieDescription,MoviePhoto from 
           dbo.Movie 
           where MovieId=@id
            ";

            var con = new SqlConnection(ConfigurationManager.
                       ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);
            
            command.Parameters.AddWithValue("@id", id);

            DataTable table = new DataTable();

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;
        }

        public static DataTable Post(Movie mov)
        {
            string query = @"
                    insert into dbo.Movie values
                    (@MovieName,
                     @MovieDirector,
                     @MovieDescription,
                     @MoviePhoto)
                    ";

            DataTable table = new DataTable();
            var con = new SqlConnection(ConfigurationManager.   
                       ConnectionStrings["MovieReviewDB"].ConnectionString);

            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@MovieName", mov.MovieName);
            command.Parameters.AddWithValue("@MovieDirector", mov.MovieDirector);
            command.Parameters.AddWithValue("@MovieDescription", mov.MovieDescription);
            command.Parameters.AddWithValue("@MoviePhoto", mov.MoviePhoto);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }

        public static DataTable Put(Movie mov)
        {
            string query = @"
                    update dbo.Movie set 
                    MovieName=@movieName
                    ,MovieDirector=@movieDirector
                    ,MovieDescription=@movieDescription
                    ,MoviePhoto=@moviePhoto

                    
                    where MovieId=@id
                    ";

            DataTable table = new DataTable();

            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@id", mov.MovieId);
            command.Parameters.AddWithValue("@movieName", mov.MovieName);
            command.Parameters.AddWithValue("@movieDirector", mov.MovieDirector);
            command.Parameters.AddWithValue("@movieDescription", mov.MovieDescription);
            command.Parameters.AddWithValue("@moviePhoto", mov.MoviePhoto);
         

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }

        public static DataTable Delete(int id)
        {
            string query = @"
                    delete from dbo.Movie where MovieId=@id
                    ";

            DataTable table = new DataTable();



            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@id", id);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }


    }

}
