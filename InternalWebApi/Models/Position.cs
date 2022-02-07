using System;
using System.Collections.Generic;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastUser { get; set; }
        public DateTime? LastDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
