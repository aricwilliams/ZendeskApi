using Api.Models.DBUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.IRepository
{
    public interface ITicketRepository
    {
        //Tickets in ICollection is the model in dbusers
        ICollection<Tickets> GetTickets();
        //this gets one ticket, so return an ticket object
        Tickets GetTicket(int ticketId);
        //now we will check if ticket is present by id
        bool TicketExists(int id);
        //now we will create ticket, when we do so we will be passing a ticket object 
        bool CreateTicket(Tickets tickets);
        bool UpdateTicket(Tickets tickets);
        //we could delete based on object or ID
        bool DeleteTicket(Tickets tickets);
        bool Save();

    }
}
//here we add all the methods for CRUD operations on tickets