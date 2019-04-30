using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Person
    {
        [Key]
        public int PId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //foriegn key
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}