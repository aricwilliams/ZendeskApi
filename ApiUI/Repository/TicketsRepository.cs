using ApiUI.Models;
using ApiUI.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiUI.Repository
{
    //with this i can access all the meathods in repository 
    public class TicketsRepository : Repository<Tickets>, iTicketsRepository
    {
        //implement clientfactory with dependecy injection
        private readonly IHttpClientFactory _clientFactory;

        public TicketsRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}

