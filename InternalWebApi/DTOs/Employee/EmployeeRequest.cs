using System.ComponentModel.DataAnnotations;

namespace InternalWebApi.DTOs.Employee
{
    public class EmployeeRequest
    {
        public int? EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name, maximun length 50")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Name, maximun length 50")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser {get;set;}
        public int SectionId {get;set;}
        public int PositionId {get;set;}
    }
}