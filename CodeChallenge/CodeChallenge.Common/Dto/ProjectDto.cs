using System;
namespace CodeChallenge.Common.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
    }
}
