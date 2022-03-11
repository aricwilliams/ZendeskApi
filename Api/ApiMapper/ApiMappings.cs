using Api.Models.DBUsers;
using Api.Models.DBUsers.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ApiMapper
{
    //inherit from using automapper
    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            //reverse map will map both ways 
            CreateMap<Tickets, TicketsDto>().ReverseMap();
        }
    }
}
