using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;
using InterrollTest.Models;
using Newtonsoft.Json;
using System.Text;

namespace InterrollTest.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class MentorController : ControllerBase

    {
        [HttpGet]
        public async Task<UserObject> GetUserData()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Basic YXJpY3dpbGxpYW1zdDJAZ21haWwuY29tOk1lZXR0aGVibGFja3M0");
            var response = await client.GetAsync("https://InterrollTest.zendesk.com/api/v2/users/me.json");
            var str = await response.Content.ReadAsStringAsync();
            UserObject user = JsonConvert.DeserializeObject<UserObject>(str);
            return user;
        }
     

        [Route("SendTicket")]
        [HttpPost]
        public async Task<TicketResponseObject> SendTicket()
        {
            var client = new HttpClient();
            //var client = new RestClient("https://InterrollTest.zendesk.com/api/v2/tickets");

            client.DefaultRequestHeaders.Add("Authorization", "Basic YXJpY3dpbGxpYW1zdDJAZ21haWwuY29tOk1lZXR0aGVibGFja3M0");
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var ticketRequest = new TicketRequestObject()
            {
                Ticket = new TicketRequest
                {
                    Comment = new TicketComment()
                    {
                        Body = "The Internet Keeps Dropping"
                    },
                    Subject = "SAP is not working",
                    Priority = "urgent"
                }
            };
            var bodyJson = JsonConvert.SerializeObject(ticketRequest);

            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://InterrollTest.zendesk.com/api/v2/tickets", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                TicketResponseObject ticketResponse = JsonConvert.DeserializeObject<TicketResponseObject>(str);
                Console.WriteLine(str);
                return ticketResponse;
            }
            else
            {
                return null;
            }
        }
    }
}

