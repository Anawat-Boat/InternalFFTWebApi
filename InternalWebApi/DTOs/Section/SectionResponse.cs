namespace InternalWebApi.DTOs.Section
{
    public class SectionResponse
    {
        public string DepartmentName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public static SectionResponse FromSection(Models.Section section)
        {
            return new SectionResponse
            {
                DepartmentName = section.Department.DepartmentName,
                SectionId = section.SectionId,
                SectionName = section.SectionName,
            };
        }
    }
}