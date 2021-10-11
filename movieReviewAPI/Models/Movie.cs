using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieReviewAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
        public string MovieReleaseDate { get; set; }
        public string MovieDescription{ get; set; }
        public string MoviePhoto { get; set; }
    }
}