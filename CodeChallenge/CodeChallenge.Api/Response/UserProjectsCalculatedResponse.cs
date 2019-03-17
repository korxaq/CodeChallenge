namespace CodeChallenge.Api.Response
{
    public class UserProjectsCalculatedResponse
    {
        public int ProjectId { get; set; }
        public string StartDate { get; set; }
        public string TimeToStart { get; set; }
        public string EndDate { get; set; }
        public int Credits { get; set; }
        public string Status { get; set; }
    }
}
