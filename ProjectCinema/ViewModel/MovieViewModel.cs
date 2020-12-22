using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCinema.Models;

namespace ProjectCinema.ViewModel
{
    public class MovieViewModel
    {
        public Movie movie { get; set; }

        public List<Movie> movies { get; set; }
    }
}