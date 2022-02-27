using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApplication.Models
{
    public class Report
    {
        public string id { get; set; }
        public string reportDate { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public int numberOfPeople { get; set; }
        public int numberOfPhone { get; set; }
    }
}
