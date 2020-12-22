using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectCinema.Models;


namespace ProjectCinema.Models
{
    public class Movie
    {

        [Key]
        [Required]
        public string ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public DateTime showtime { get; set; }

        [Required]
        public string price { get; set; }


        [Required]
        public string SALLE { get; set; }

        [Required]
        public string moviePicture { get; set; }


    }
}