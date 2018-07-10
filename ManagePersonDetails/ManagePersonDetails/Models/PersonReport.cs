using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.Models
{
    public class PersonReport
    {
        public long PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
    }
}