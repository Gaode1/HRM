namespace ApplicationCore.Entities;

public class Submission
{
    public int JobId { get; set; }
    public int CandidateId { get; set; }
    public DateTime? SubmittedOn { get; set; }
    public DateTime? ApprovedForInterview { get; set; }
    public DateTime? RejectedOn { get; set; }
    public string RejectReason { get; set; }
}