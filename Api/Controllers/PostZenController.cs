using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Api.Models;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace Api.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class PostZenController : Controller

    {

        [HttpGet]
        public async Task<List<LAticket>> GetUserData()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("apikey", Client.AUTHLA);
            var response = await client.GetAsync("https://interroll4.ladesk.com/api/v3/tickets");
            var str = await response.Content.ReadAsStringAsync();
            List<LAticket> user = JsonConvert.DeserializeObject<List<LAticket>>(str);
            return user;
        }

         [Route("SendTicket")]
         [HttpPost]
         public async Task<TicketResponseObject> SendTicket(TicketRequestObject ticketRequest)
         {
             var client = new HttpClient();
             client.DefaultRequestHeaders.Add("Authorization", Client.AUTH);
            //make into anothr func^^^^^
             var TicketRequest = new TicketRequestObject()
             {
                 ticket = new TicketRequest
                 {
                     comment = new TicketComment()
                     {
                         body = "The smoke is very Colorfull"
                     },
                     subject = "My printer is on fire!",
                     priority = "urgent"
                 }
             };
             var bodyJson = JsonConvert.SerializeObject(ticketRequest);
            //7overloads 1stone^^^^take and make lowercase //method signature 
             var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
             var response = await client.PostAsync("https://Interroll3.zendesk.com/api/v2/tickets", stringContent);
            var str = await response.Content.ReadAsStringAsync();
                 TicketResponseObject ticketResponse = JsonConvert.DeserializeObject<TicketResponseObject>(str);
                 Console.WriteLine(str);
                 return ticketResponse;
           
         }
    }
}

//we have public properties in the models folder. Thoes properties is what the Api expects... in c# we have them as objects, but they will be sent as a string (JSON) to the API... if we were doing Javascript we could just use JSON

//Line32
//this is an async function.That returns a task
//sendticket is a method that takes in a ticket request object from zendesk. this comes in JSON type. In line 51 we convert to 

//Line33
//use Http client when reqsting Api

//Line36
//these are classes we created. now we use new to make it objects

//Line47
//we turn this into JSON string with Newtonsoft JSON library (do JSON whings in c#). JsonConvert is a function with SerializeObject (takes object and turn into string)

//Line49
//New StringContent is apart of System.Net.Http namespace this allows us to put a string into the Http call... the paramerters are 1st the content, use encoding.utf8 this make sures any special characters are ok (!@#$) this comes from system.text using statment, finnally the media type... we using JSON

//Line50
//PostAsync posts to the enpoint with the uri & stringcontent (our payload in the Https request)

//Line51
//content is just a part of the response object.. use Content.ReadAsStringAsync() to get the content (json) result back as a string Asynchronously https://Interroll4.zendesk.com/api/v2/users/me.json