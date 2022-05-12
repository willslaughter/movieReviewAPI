
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using movieReviewAPI.Models;

namespace movieReviewAPI.Services
{
    public class UserDAO
    {


        public static DataTable Get()
        {
            string query = @"select UserId,UserName from 
            dbo.SiteUser
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
            string query = @"select UserId,UserName from 
            dbo.SiteUser where UserId=@id
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
        
        public static DataTable GetByName(string name)
        {
            string query = @"select UserId, UserName from 
            dbo.SiteUser where UserName=@name
            ";

            DataTable table = new DataTable();
            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@name", name);
            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return table;

        }

        public static DataTable Post(SiteUser usr)
        {
            string query = @"
                    insert into dbo.SiteUser values
                    (@name)
                    ";

            DataTable table = new DataTable();


            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@name", usr.UserName);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;

        }

        public static DataTable Put(SiteUser usr)
        {
            string query = @"
                    update dbo.SiteUser set 

                    UserName=@name,
                    adminFlag=@admin

                    where UserId=@id
                    ";

            DataTable table = new DataTable();
            var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["MovieReviewDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@id", usr.UserId);
            command.Parameters.AddWithValue("@name", usr.UserName);
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
                    delete from dbo.SiteUser where UserId=@id
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