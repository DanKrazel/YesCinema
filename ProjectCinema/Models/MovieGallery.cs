using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.Models
{
    public class MovieGallery
    {
        public string MovieName { get; set; }
        public string MoviePicture { get; set; }
        public string TimeMovie { get; set; }
    }
}