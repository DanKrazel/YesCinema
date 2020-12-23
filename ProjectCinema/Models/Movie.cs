using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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

        [Required]
        public string moviePicture { get; set; }

        public void Delete(int id)
        {
            string conString = ConfigurationManager.ConnectionStrings["EmpContext"].ConnectionString;

            string strDelete = "delete tblemp  where EmpID=" + id;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(strDelete, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}