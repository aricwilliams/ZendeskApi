using Api.Data;
using Api.Models.DBUsers;
using Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class TicketRepository : ITicketRepository
    {
        //this is an object to access the database 
        private readonly ApplicationDbContext _db;

        //this is a contructor to get the connection using dependecy injection... using _db I can access the databse 
        public TicketRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTicket(Tickets tickets)
        {
            //this will add tickets we pass through this function to the db
            _db.Tickets.Add(tickets);
            return Save();
        }

        public bool DeleteTicket(Tickets tickets)
        {
            _db.Tickets.Remove(tickets);
            return Save();
        }

        //get a specific ticket
        public Tickets GetTicket(int ticketId)
        {
            //get ticket from databse that has the id we pass to it
            return _db.Tickets.FirstOrDefault(a => a.Id == ticketId);
        }

        //get all tickets
        public ICollection<Tickets> GetTickets()
        {
            //return a list 
            return _db.Tickets.OrderBy(a => a.title).ToList();
        }

        public bool Save()
        {
            //save changes, if this is equal or grater then zero return true elts return false
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool TicketExists(int id)
        {
            return _db.Tickets.Any(a => a.Id == id);
        }
        //This is for user posting a ticket to database.... Capital Title is user input, Lowercase title is from Tickets model
        public bool TicketExistsPost(string Title)
        {
            return _db.Tickets.Any(a => a.title == Title);
        }

        public bool UpdateTicket(Tickets tickets)
        {
            _db.Tickets.Update(tickets);
            return Save();
        }
    }
}
