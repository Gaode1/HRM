namespace ApplicationCore.Entities;

public class Candidate
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int NumOfJobsApplied { get; set; }
    public List<Submission> Submissions { get; set; }
}