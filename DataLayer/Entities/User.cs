using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserRole Role { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }

    }
}
