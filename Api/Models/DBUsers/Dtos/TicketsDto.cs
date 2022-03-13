using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DBUsers.Dtos
{
    public class TicketsDto
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string comment { get; set; }
       // public DateTime Created { get; set; }
        //public byte[] Picture { get; set; }
        //public DateTime Established { get; set; }
    }
}
//this is the model that represents our API 