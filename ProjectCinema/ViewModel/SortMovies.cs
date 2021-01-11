using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectCinema.ViewModel
{
    public class SortMovies
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public string sortShowtime { get; set; }

        public int StudentCount { get; set; }
    }
}