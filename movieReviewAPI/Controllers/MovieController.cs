using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using movieReviewAPI.Models;

namespace movieReviewAPI.Controllers
{
    public class MovieController : ApiController
    {
        // GET: Movie
        public HttpResponseMessage Get()
        {
            string query = @"select MovieId,MovieName,MovieDirector,MovieReleaseDate,MovieDescription,MoviePhoto from 
            dbo.Movie
            ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection (ConfigurationManager.
                       ConnectionStrings["MovieReviewDB"].ConnectionString))
                       using (var cmd= new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Movie mov)
        {
            try
            {
                string query = @"
                    insert into dbo.Movie values
                    ('"+mov.MovieName+ @"'
                     ,'" +mov.MovieDirector+ @"'
                     ,'" +mov.MovieReleaseDate+ @"'
                     ,'" +mov.MovieDescription+ @"'
                     ,'" +mov.MoviePhoto+ @"'
)
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

                return "Added Sucess!";

            }
            catch(Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(Movie mov)
        {
            try
            {
                string query = @"
                    update dbo.Movie set 
                    MovieName='" + mov.MovieName + @"'
                    ,MovieDirector='" + mov.MovieDirector + @"'
                    ,MovieReleaseDate='" + mov.MovieReleaseDate + @"'
                    ,MovieDescription='" + mov.MovieDescription + @"'
                    ,MoviePhoto='" + mov.MoviePhoto + @"'
                    where MovieId=" + mov.MovieId + @"
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

                return "Update Sucess!";

            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Movie where MovieId=" + id + @"
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

                return "Delete Sucess!";

            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

        
        [Route("api/Movie/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch(Exception)
            {
                return "anonymous.png";
            }
        }
    }
}