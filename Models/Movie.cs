using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apifreader.Models
{
    public class Movie
    {
        public int movieId { get; set; }

        public string movieName { get; set; }

        public string cast { get; set; }

        public DateTime dateOfRelease { get; set; }

       public string genre { get; set; }

       public byte[] image { get; set; }
    }
}