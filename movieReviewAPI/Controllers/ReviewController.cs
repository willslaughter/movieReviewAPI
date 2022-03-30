using System;
using System.Web.Http;
using System.Net.Http;
using System.Data;
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

            return Request.CreateResponse(HttpStatusCode.OK, ReviewDAO.Get());

        }


        public HttpResponseMessage Get(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK, ReviewDAO.GetById(id));

        }


        public string Post(Review rev)
        {
            try
            {
                DataTable table = ReviewDAO.Post(rev);

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

                DataTable table = ReviewDAO.Put(rev);

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
                DataTable table = ReviewDAO.Delete(id);

                return "Delete Sucess!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

       
    }
}