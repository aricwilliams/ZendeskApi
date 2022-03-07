using InterrollTest.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace InterrollTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZendeskRespController : ControllerBase

    {
        List<ZendeskResp> responses = new List<ZendeskResp>()
       {
           new ZendeskResp()
           {
               SuccessIT = "Thank You, IT Support Will Contact you soon",
               SuccessEN = "Thank You For Making A Ticket, Enginnering Support Will Be With You Soon",
               Failed = "mmmmm...Something went wrong...Try Agin"
    }
       };

        public IEnumerable<ZendeskResp> Getresponses()
        {
            return responses;
        }
    }
}
