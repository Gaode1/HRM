using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Candidate
{
    public int Id { get; set; }
    public Guid CandidateIdentityId { get; set; }
    [StringLength(100)]
    public string FirstName { get; set; }
    [StringLength(50)]
    public string? MiddleName { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(512)]
    public string Email { get; set; }

    public DateTime CreatedOn { get; set; }

    [StringLength(2048)]
    public string ResumeURL { get; set; }
    // public List<Submission> Submissions { get; set; }
}