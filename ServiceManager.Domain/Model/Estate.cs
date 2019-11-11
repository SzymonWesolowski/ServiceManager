using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Estate
    {
        public Estate(string name, CityEnum city, string street, string postCode, Inspector inspector)
        {
            Name = name;
            City = city;
            Street = street;
            PostCode = postCode;
            Inspector = inspector;
        }

        public string Name { get; }
        public CityEnum City { get; }
        public string Street { get; }
        public string PostCode { get; }
        public Inspector Inspector { get; }
    }
}
