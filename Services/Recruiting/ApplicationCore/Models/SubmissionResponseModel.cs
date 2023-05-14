namespace ApplicationCore.Models;

public class SubmissionResponseModel
{
    public int JobId { get; set; }
    public int CandidateId { get; set; }
    public string RejectReason { get; set; }
}