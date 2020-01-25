using System;

namespace ServiceManager.Domain.Model
{
    public class Serviceman
    {
        public Serviceman(string firstName, string lastName, string permissionNumber, Guid servicemanId)
        {
            FirstName = firstName;
            LastName = lastName;
            PermissionNumber = permissionNumber;
            ServicemanId = servicemanId;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string PermissionNumber { get; }
        public Guid ServicemanId { get; }
    }
}
