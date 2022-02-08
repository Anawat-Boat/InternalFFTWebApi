
namespace InternalWebApi.DTOs.Department
{
    public class DepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public static DepartmentResponse FromDepartment(Models.Department department)
        {
            return new DepartmentResponse
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }
    }
   
}