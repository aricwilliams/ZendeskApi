using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DBUsers
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string comment { get; set; }
        //public DateTime Created { get; set; }
        //public byte[] Picture { get; set; }
        //public DateTime Established { get; set; }
    }
}
//this is the domain model we use.... we will make another one that represent our API 