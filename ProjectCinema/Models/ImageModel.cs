using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace ProjectCinema.Models
{
    public class ImageModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        
    }

}
