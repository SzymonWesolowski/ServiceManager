using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServiceManager.Domain.Model
{
    public class EstateDbDto
    {

        [Key]
        public Guid EstateId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public Guid InspectorId { get; set; }
        public bool UnderContract { get; set; }
        public DateTime LastInspectionDate { get; set; }
    }
}
