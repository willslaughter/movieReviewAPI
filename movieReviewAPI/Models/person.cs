using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieReviewAPI.Models
{
    public class person
    {
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public bool adminFlag { get; set; }

    }
}