using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.Models
{
    public class PersonContact
    {
        public long ID { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public long PerosnID { get; set; }
        
    }
}