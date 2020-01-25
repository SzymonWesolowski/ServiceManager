using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceManager.Domain.Model
{
    public class InspectorDbDto
    {

        [Key]
        public Guid InspectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}