using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCinema.Models;

namespace ProjectCinema.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
    }
}