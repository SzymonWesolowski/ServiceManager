using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Estate
    {
        public Estate(string name, string city, string street, string postCode, Inspector inspector, bool underContract, DateTime lastInspectionDate)
        {
            Name = name;
            City = city;
            Street = street;
            PostCode = postCode;
            Inspector = inspector;
            UnderContract = underContract;
            LastInspectionDate = lastInspectionDate;
        }

        public string Name { get; }
        public string City { get; }
        public string Street { get; }
        public string PostCode { get; }
        public Inspector Inspector { get; }
        public bool UnderContract { get; }
        public DateTime LastInspectionDate { get; }
    }
}
