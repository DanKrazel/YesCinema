using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Models
{
	public class Tickets
	{
        [Key]
        public string ID { get; set; }
        [Required]
        public string MOVIENAME { get; set; }
        [Required]       
        public DateTime SHOWTIME { get; set; }
        [Required]
        public string SEAT { get; set; }
        [Required]
        public string COST { get; set; }

    }
}