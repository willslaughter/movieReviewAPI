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

namespace movieReviewAPI.Services
{
    public class ReviewService
    {
        public static DataTable reviewService(string query)
        {
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
    }
}