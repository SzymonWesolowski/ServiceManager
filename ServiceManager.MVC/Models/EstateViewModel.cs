using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceManager.MVC.Models
{
    public class EstateViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string InspectorId { get; set; }
        public bool UnderContract { get; set; }
        public string EstateId { get; set; }


    }
}
