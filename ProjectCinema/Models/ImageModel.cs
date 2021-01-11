using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProjectCinema.Models
{
    public class ImageModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Image { get; set; }
        
    }

}
