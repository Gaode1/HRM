using ApplicationCore.Entities;

namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int CandidateId { get; set; }
    public DateTime? ApprovedForInterview { get; set; }
    public DateTime? RejectedOn { get; set; }
    public string? RejectReason { get; set; }
}