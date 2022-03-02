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
    public class ReviewController : ApiController
    {
        // GET: Review
        public HttpResponseMessage Get()
        {
            string query = @"select ReviewId,MovieId,Rating,ReviewDescription from 
            dbo.Review
            ";

            DataTable table = ReviewService.reviewService(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        public HttpResponseMessage Get(int id)
        {
            string query = @"select ReviewId,MovieId,Rating,ReviewDescription from 
            dbo.Review where MovieId=" + id + @"
            ";

            DataTable table = ReviewService.reviewService(query);

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        public string Post(Review rev)
        {
            try
            {
                string query = @"
                    insert into dbo.Review values
                    ('" +rev.MovieId+ @"',
                     '" +rev.Rating+ @"',
                     '" +rev.ReviewDescription+ @"'
)
                    ";

                DataTable table = ReviewService.reviewService(query);

                return "Added Sucess!";

            }
            catch(Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(Review rev)
        {
            try
            {
                string query = @"
                    update dbo.Review set 
                    Rating='" + rev.Rating + @"'
                    where Review=" + rev.ReviewId + @"
                    ";

                DataTable table = ReviewService.reviewService(query);

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
                    delete from dbo.Review where ReviewId=" + id + @"
                    ";

                DataTable table = ReviewService.reviewService(query);

                return "Delete Sucess!";

            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

       
    }
}