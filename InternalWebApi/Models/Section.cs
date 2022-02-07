using System;
using System.Collections.Generic;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class Section
    {
        public Section()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
