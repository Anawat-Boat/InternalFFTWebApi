using System.ComponentModel.DataAnnotations;

namespace InternalWebApi.DTOs.Position
{
    public class PositionRequest
    {
        public int? PositionId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name, maximun length 50")]
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string LastUser {get;set;}
    }
}