using System;
using System.Collections.Generic;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class Employee
    {
        public int SectionId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser { get; set; }

        public virtual Position Position { get; set; }
        public virtual Section Section { get; set; }
    }
}
