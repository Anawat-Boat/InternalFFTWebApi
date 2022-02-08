using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace InternalWebApi.DTOs.Section
{
    public class SectionRequest
    {

        public int? SectionId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name, maximun length 50")]
        public string SectionName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser {get;set;}
        public int DepartmentId {get;set;}
    }
}