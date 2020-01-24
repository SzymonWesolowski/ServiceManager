using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServiceManager.Domain.Model
{
    public class ServicemanDbDto
    {
        [Key]
        public Guid ServicemanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermissionNumber { get; set; }
    }
}
