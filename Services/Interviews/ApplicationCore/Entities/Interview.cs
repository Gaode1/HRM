using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Interview
{
    public int  Id { get; set; }
    [Required]
    public DateTime BeginTime { get; set; }
    [Required]
    [StringLength(128)]
    public string CandidateEmail { get; set; }
    [Required]
    [StringLength(128)]
    public string CandidateFirstName { get; set; }
    [Required]
    [StringLength(128)]
    public string CandidateLastName { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    public string Feedback { get; set; }
    [Required]
    public int InterviewerId { get; set; }
    [Required]
    public int InterviewerTypeId { get; set; }

    public bool Passed { get; set; }

    public int Rating { get; set; }
    [Required]
    public int SubsmissionId { get; set; }
}