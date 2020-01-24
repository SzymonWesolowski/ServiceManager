using System;

namespace ServiceManager.Domain.Model
{
    public class Inspector
    {
        public Inspector(string firstName, string lastName, string city, string phoneNumber, Guid inspectorId)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            PhoneNumber = phoneNumber;
            InspectorId = inspectorId;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string City { get; }
        public string PhoneNumber { get; }
        public Guid InspectorId { get; }
    }
}