using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieReviewAPI.Models
{
    public class review
    {
        public int movie_id { get; set; }
        public int person_id { get; set; }
        public double review_rating { get; set; }
        public string update_ts { get; set; }
        public string create_ts { get; set; }
    }
}