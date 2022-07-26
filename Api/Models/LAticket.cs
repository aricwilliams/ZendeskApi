using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class LAticket
    {

        public string id { get; set; }
        public string owner_contactid { get; set; }
        public string owner_email { get; set; }
        public string owner_name { get; set; }
        public string departmentid { get; set; }
        public string status { get; set; }
        public List<object> tags { get; set; }
        public string code { get; set; }
        public string channel_type { get; set; }
        public string date_created { get; set; }
        public string date_changed { get; set; }
        public string last_activity { get; set; }
        public string last_activity_public { get; set; }
        public string public_access_urlcode { get; set; }
        public string subject { get; set; }
        public List<object> custom_fields { get; set; }
        public string agentid { get; set; }



    }
}
