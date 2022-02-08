namespace InternalWebApi.DTOs.Employee
{
    public class EmployeeResponse
    {
        
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentName {get;set;}
        public string SectionName { get; set; }
        public string PositionName { get; set; }
        public static EmployeeResponse FromEmployee(Models.Employee employee)
        {
            return new EmployeeResponse
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                SectionName = employee.Section.SectionName,
                PositionName = employee.Position.PositionName,
                DepartmentName = employee.Section.Department.DepartmentName
            };
        }
    }
}