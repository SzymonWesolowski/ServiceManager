using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Serviceman
    {
        public Serviceman(string firstName, string lastName, string permissionNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PermissionNumber = permissionNumber;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string PermissionNumber { get; }
    }
}
