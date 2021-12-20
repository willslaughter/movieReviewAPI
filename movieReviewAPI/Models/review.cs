using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieReviewAPI.Models
{
    public class Review
    {   
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }

    }
}