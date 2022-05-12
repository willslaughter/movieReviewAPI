using System;
using System.Web.Http;
using System.Net.Http;
using System.Data;
using System.Net;
using movieReviewAPI.Models;
using movieReviewAPI.Services;

namespace movieReviewAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET: User
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, UserDAO.Get());

        }


        public HttpResponseMessage Get(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK, UserDAO.GetById(id));

        }

        [Route("api/user/GetByName/{name}")]
        [HttpGet]
        public HttpResponseMessage GetByName(string name)
        {

            return Request.CreateResponse(HttpStatusCode.OK, UserDAO.GetByName(name));

        }


        public string Post(SiteUser usr)
        {
            try
            {
                DataTable table = UserDAO.Post(usr);

                return "Added Sucess!";

            }
            catch(Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(SiteUser usr)
        {
            try
            {

                DataTable table = UserDAO.Put(usr);

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
                DataTable table = UserDAO.Delete(id);

                return "Delete Sucess!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

       
    }
}