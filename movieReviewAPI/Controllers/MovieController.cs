using System;
using System.Web.Http;
using System.Net.Http;
using System.Data;
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
            return Request.CreateResponse(HttpStatusCode.OK, MovieDAO.Get());

        }
        
        

        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, MovieDAO.GetById(id));

        }
        

        [Route("api/movie/GetRatingAverage/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRatingAverage(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ReviewDAO.GetRatingAverageById(id));

        }
        

        public string Post(Movie mov)
        {
            try
            {

                DataTable table = MovieDAO.Post(mov);

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
                DataTable table = MovieDAO.Put(mov);

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

                DataTable table = MovieDAO.Delete(id);

                return "Delete Sucess!";

            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

        
    }
}