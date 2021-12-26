using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformationSiteForSmartPhones.Entities
{
    public class SmartPhones
    {
        public int Id { get; set; }
        public int IdToSmartPhone { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string InteralMemory { get; set; }

        public string RamMemory { get; set; }
        public string ResolutionOfCamera { get; set; }


    }
}