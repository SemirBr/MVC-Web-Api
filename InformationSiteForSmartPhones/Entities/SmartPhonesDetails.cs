using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationSiteForSmartPhones.Entities
{
    public class SmartPhonesDetails
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public string NameOfSmartPhone { get; set; }

        public string Details { get; set; }
    }
       
}