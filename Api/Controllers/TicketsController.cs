using Api.Models.DBUsers;
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


        //now lets get a single ticket based on the ID. then based one the ID we need to retrive the object 
        //also in this Https get we pass an expected parameter of ticketId... if not we would get an err...{not able to tell the diffrence between the Http get call from above}
        //GetTicketReturn is assigned as the name because we need to return the ticket made when user submits via post request
        [HttpGet("{ticketId:int}", Name = "GetTicketReturn")]
        public IActionResult GetTicket(int ticketId)
        {
            //pass the id here to retrive that object from the repository (a class that contains methods wich calls from the database)
            var obj = _ticketRepo.GetTicket(ticketId);
            if (obj == null)
            {
                return NotFound();
            }
            //once we found the object, lets convert into a Dto before returning 
            var objDto = _mapper.Map<TicketsDto>(obj);
            return Ok(objDto);
        }

        //time to make a ticket, we will be getting data (a ticket Dto {this is what the user gives us. a column in the database}) from the body. 
        //we will get a TicketsDto & we will call it ticketsDto 
        [HttpPost]
        public IActionResult CreateTicket([FromBody] TicketsDto ticketDto)
        {
            //if ticketDto does not exist, return modelstate (errors)
            if (ticketDto == null)
            {
                return BadRequest(ModelState);
            }
            //if dplicate then add an error 
            if (_ticketRepo.TicketExistsPost(ticketDto.title))
            {
                ModelState.AddModelError("", "Ticket Title Is Already Made, Change title!!");
                return StatusCode(404, ModelState);
            }
           
            //convert the Dto to our domain model
            var ticketObj = _mapper.Map<Tickets>(ticketDto);
            if (!_ticketRepo.CreateTicket(ticketObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving ticket {ticketObj.title}");
                return StatusCode(500, ModelState);
            }
            //return an object that was just created
            //created at rote will give a status code 201 back & show what was just created because we are calling GetTicketReturn passing the title... it will retreve that and show it....soooo.... the 3 things (objects) we are passing are the route name, route value, all the values (ticketObj) sooooo basically we using CreatedAtRoute to pass the actual onject that was created in the HttpPost request 
            return CreatedAtRoute("GetTicketReturn", new { ticketTitle = ticketObj.title}, ticketObj);
        }

        
    }
}
