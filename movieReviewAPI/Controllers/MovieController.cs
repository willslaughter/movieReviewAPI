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
using movieReviewAPI.Services;

namespace movieReviewAPI.Controllers
{
    public class MovieController : ApiController
    {
        // GET: Movie
        public HttpResponseMessage Get()
        {
            string query = @"select MovieId,MovieName,MovieDirector,MovieDescription,MoviePhoto,ReviewAverage from 
            dbo.Movie
            ";

            DataTable table = MovieService.movieService(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        
        

        public HttpResponseMessage Get(int id)
        {
            string query = @"select MovieId,MovieName,MovieDirector,MovieDescription,MoviePhoto,ReviewAverage from 
            dbo.Movie where MovieId=" + id + @"
            ";

            DataTable table = MovieService.movieService(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        

        [Route("api/movie/GetRatingAverage/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRatingAverage(int id)
        {
            string query = @"select AVG(Rating) from 
            dbo.Review where MovieId=" + id + @"
            ";

            DataTable table = ReviewService.reviewService(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        

        public string Post(Movie mov)
        {
            try
            {
                string query = @"
                    insert into dbo.Movie values
                    ('" + mov.MovieName + @"'
                     ,'" + mov.MovieDirector + @"'
                     ,'" + mov.MovieDescription + @"'
                     ,'" + mov.MoviePhoto + @"'
                     ,'" + mov.ReviewAverage + @"'
                   
)
                    ";

                DataTable table = MovieService.movieService(query);

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
                    ,MovieDescription='" + mov.MovieDescription + @"'
                    ,MoviePhoto='" + mov.MoviePhoto + @"'
                    ,ReviewAverage='" +mov.ReviewAverage + @"'
                    
                    where MovieId=" + mov.MovieId + @"
                    ";

                DataTable table = MovieService.movieService(query);

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

                DataTable table = MovieService.movieService(query);

                return "Delete Sucess!";

            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

        
    }
}