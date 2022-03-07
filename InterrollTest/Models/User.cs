using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterrollTest.Models
{
    public class UserFields
    {
    }

    public class User
    {
        public long id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string time_zone { get; set; }
        public string iana_time_zone { get; set; }
        public object phone { get; set; }
        public object shared_phone_number { get; set; }
        public object photo { get; set; }
        public int locale_id { get; set; }
        public string locale { get; set; }
        public long organization_id { get; set; }
        public string role { get; set; }
        public bool verified { get; set; }
        public string authenticity_token { get; set; }
        public object external_id { get; set; }
        public List<object> tags { get; set; }
        public object alias { get; set; }
        public bool active { get; set; }
        public bool shared { get; set; }
        public bool shared_agent { get; set; }
        public DateTime last_login_at { get; set; }
        public object two_factor_auth_enabled { get; set; }
        public object signature { get; set; }
        public object details { get; set; }
        public object notes { get; set; }
        public int role_type { get; set; }
        public long custom_role_id { get; set; }
        public bool moderator { get; set; }
        public object ticket_restriction { get; set; }
        public bool only_private_comments { get; set; }
        public bool restricted_agent { get; set; }
        public bool suspended { get; set; }
        public long default_group_id { get; set; }
        public bool report_csv { get; set; }
        public UserFields user_fields { get; set; }
    }

    public class UserObject
    {
        public User user { get; set; }
    }
}
