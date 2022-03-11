using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class TicketRequestObject
    {
        public TicketRequest ticket { get; set; }
    }
    public class TicketRequest
    {
        public string name { get; set; }
        public string priority { get; set; }
        public string subject { get; set; }
        public TicketComment comment { get; set; }
    }
    public class TicketComment
    {
        public string body { get; set; }
    }






    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class From
    {
        public bool deleted { get; set; }
        public string title { get; set; }
        public object id { get; set; }
    }

    public class To
    {
        public string name { get; set; }
        public string address { get; set; }
    }

    public class Source
    {
        public From from { get; set; }
        public To to { get; set; }
        public object rel { get; set; }
    }

    public class Via
    {
        public string channel { get; set; }
        public Source source { get; set; }
    }

    public class TicketResponse
    {
        public string url { get; set; }
        public int id { get; set; }
        public object external_id { get; set; }
        public Via via { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object type { get; set; }
        public string subject { get; set; }
        public string raw_subject { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public object recipient { get; set; }
        public long requester_id { get; set; }
        public long submitter_id { get; set; }
        public long assignee_id { get; set; }
        public long organization_id { get; set; }
        public long group_id { get; set; }
        public List<object> collaborator_ids { get; set; }
        public List<object> follower_ids { get; set; }
        public List<object> email_cc_ids { get; set; }
        public object forum_topic_id { get; set; }
        public object problem_id { get; set; }
        public bool has_incidents { get; set; }
        public bool is_public { get; set; }
        public object due_at { get; set; }
        public List<object> tags { get; set; }
        public List<object> custom_fields { get; set; }
        public object satisfaction_rating { get; set; }
        public List<object> sharing_agreement_ids { get; set; }
        public List<object> fields { get; set; }
        public List<object> followup_ids { get; set; }
        public long ticket_form_id { get; set; }
        public long brand_id { get; set; }
        public bool allow_channelback { get; set; }
        public bool allow_attachments { get; set; }
    }

    public class System
    {
        public string client { get; set; }
        public string ip_address { get; set; }
        public string location { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Custom
    {
    }

    public class Metadata
    {
        public System system { get; set; }
        public Custom custom { get; set; }
    }

    public class Event
    {
        public object id { get; set; }
        public string type { get; set; }
        public long author_id { get; set; }
        public string body { get; set; }
        public string html_body { get; set; }
        public string plain_body { get; set; }
        public bool @public { get; set; }
        public List<object> attachments { get; set; }
        public long audit_id { get; set; }
        public string value { get; set; }
        public string field_name { get; set; }
        public Via via { get; set; }
        public string subject { get; set; }
        public List<object> recipients { get; set; }
    }

    public class Audit
    {
        public long id { get; set; }
        public int ticket_id { get; set; }
        public DateTime created_at { get; set; }
        public long author_id { get; set; }
        public Metadata metadata { get; set; }
        public List<Event> events { get; set; }
        public Via via { get; set; }
    }

    public class TicketResponseObject
    {
        public TicketResponse ticket { get; set; }
        public Audit audit { get; set; }
    }


}
