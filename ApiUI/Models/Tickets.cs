using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUI.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string comment { get; set; }
        // public DateTime Created { get; set; }
        //public byte[] Picture { get; set; }
        //public DateTime Established { get; set; }
    }
}





