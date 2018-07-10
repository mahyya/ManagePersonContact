using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.Models
{
    public class Person
    {
        public long ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public List<PersonContact> PersonContact { get; set; }        
        public List<PersonReport> ListPerson { get; set; }
    }
}