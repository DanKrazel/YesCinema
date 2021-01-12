using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCinema.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Number { get; set; }
        [Key]
        public string UserID { get; set; }
        [Required]
        public string Hall { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}