using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace Api.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class PostZenController : Controller

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
        ///////

        [Route("SendTicket")]
        [HttpPost]
        public async Task<TicketResponseObject> SendTicket(TicketRequestObject ticketRequest)
        {
            var client = new HttpClient();
            //var client = new RestClient("https://InterrollTest.zendesk.com/api/v2/tickets");

            client.DefaultRequestHeaders.Add("Authorization", "Basic YXJpY3dpbGxpYW1zdDJAZ21haWwuY29tOk1lZXR0aGVibGFja3M0");
            var TicketRequest = new TicketRequestObject()
            {
                Ticket = new TicketRequest
                {
                    Comment = new TicketComment()
                    {
                        Body = "The smoke is very Colorful"
                    },
                    Subject = "My printer is on fire!",
                    Priority = "urgent"
                }
            };
            var bodyJson = JsonConvert.SerializeObject(TicketRequest);

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


