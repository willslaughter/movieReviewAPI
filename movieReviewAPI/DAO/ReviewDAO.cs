
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using movieReviewAPI.Models;

namespace movieReviewAPI.Services
{
    public class ReviewDAO
    {

        public static DataTable GetRatingAverageById(int id)
        {
            string query = @"select AVG(Rating) from 
            dbo.Review where MovieId=@id
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

        public static DataTable Get()
        {
            string query = @"select ReviewId,MovieId,Rating,ReviewDescription,UserName from 
            dbo.Review
            ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                       ConnectionStrings["MovieReviewDB"].ConnectionString))
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
            string query = @"select ReviewId,MovieId,Rating,ReviewDescription,UserName from 
            dbo.Review where MovieId=@id
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

        public static DataTable Post(Review rev)
        {
            string query = @"
                    insert into dbo.Review values
                    (@id,
                     @rating,
                     @reviewDescription,
                     @userName
)
                    ";

            DataTable table = new DataTable();


            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@id", rev.MovieId);
            command.Parameters.AddWithValue("@rating", rev.Rating);
            command.Parameters.AddWithValue("@reviewDescription", rev.ReviewDescription);
            command.Parameters.AddWithValue("@userName", rev.UserName);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }

        public static DataTable Put(Review rev)
        {
            string query = @"
                    update dbo.Review set 
                    Rating=@rating
                    where Review=@review
                    ";

            DataTable table = new DataTable();
            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@rating", rev.Rating);
            command.Parameters.AddWithValue("@review", rev.ReviewId);
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
                    delete from dbo.Review where ReviewId=@id
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