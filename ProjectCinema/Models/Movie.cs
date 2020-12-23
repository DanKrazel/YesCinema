﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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


        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string moviePicture { get; set; }




    }
}