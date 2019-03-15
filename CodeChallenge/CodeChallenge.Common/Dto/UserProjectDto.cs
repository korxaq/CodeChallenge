using System;
namespace CodeChallenge.Common.Dto
{
    public class UserProjectDto
    {
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
