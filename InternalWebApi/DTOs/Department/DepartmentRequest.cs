using System.ComponentModel.DataAnnotations;

namespace InternalWebApi.DTOs.Department
{
    public class DepartmentRequest
    {
        public int? DepartmentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name, maximun length 50")]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser {get;set;}
    }
}