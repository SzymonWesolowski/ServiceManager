using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Estate
    {
        public Estate(string name, string city, string street, string postCode, bool underContract,
            DateTime lastInspectionDate, Guid estateId, Guid inspectorId)
        {
            Name = name;
            City = city;
            Street = street;
            PostCode = postCode;
            UnderContract = underContract;
            LastInspectionDate = lastInspectionDate;
            EstateId = estateId;
            InspectorId = inspectorId;
        }

        public string Name { get; }
        public string City { get; }
        public string Street { get; }
        public string PostCode { get; }
        public Guid  InspectorId { get; }
        public bool UnderContract { get; }
        public DateTime LastInspectionDate { get; }
        public Guid EstateId { get; }
    }
}
