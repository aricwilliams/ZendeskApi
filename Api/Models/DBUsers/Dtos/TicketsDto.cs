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
        public string title { get; set; }
        public string comment { get; set; }
       // public DateTime Created { get; set; }
        //public byte[] Picture { get; set; }
        //public DateTime Established { get; set; }
    }
}
//this is the model that represents our API 