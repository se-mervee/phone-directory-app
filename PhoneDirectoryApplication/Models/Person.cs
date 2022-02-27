using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApplication.Models
{
    public class Person
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
        public ContactInfo contactInfo { get; set; }
    }
}
