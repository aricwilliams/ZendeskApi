using Api.Models.DBUsers.Dtos;
using Api.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class TicketsController : Controller
    {
        //bringing this in via dependecy injection, I called it _ticketRepo & _mapper
        private ITicketRepository _ticketRepo;
        private readonly IMapper _mapper;

        //this is the constructor
        public TicketsController(ITicketRepository ticketRepo, IMapper mapper)
        {
            //now i can use this to get tickets from the db
            _ticketRepo = ticketRepo;
            _mapper = mapper;
        }
        //get all tickets from database 
        [HttpGet]
        public IActionResult GetTickets()
        {
            var objList = _ticketRepo.GetTickets();
            var objDto = new List<TicketsDto>();
            
            foreach (var obj in objList)
            {
                //We are using DTO'S we should never expose domain models to the outside world... only dto's
                //we user mapper to convert to ticketsDto
                //take the obj which is tickets and convert into ticketsDto
                objDto.Add(_mapper.Map<TicketsDto>(obj));
            }
            return Ok(objDto);
            //Again! we are using DTO'S never expose domain models to the outside world... only dto's
        }
    }
}
