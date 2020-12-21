using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectCinema.Models;

namespace ProjectCinema.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MOVIE
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "costumeur Number must be contain 9 digits ")]
        public string ID { get; set; }

        [Required]
        public DateTime showtime { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public string SALLE { get; set; }

    }

}
