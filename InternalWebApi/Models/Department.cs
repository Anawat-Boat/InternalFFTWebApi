using System;
using System.Collections.Generic;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class Department
    {
        public Department()
        {
            Sections = new HashSet<Section>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastUser { get; set; }
        public DateTime? LastDate { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
