using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Job
{
    public int Id { get; set; }
    public Guid JobCode { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    [MaxLength(3000)]
    public string Description { get; set; }
    public bool? IsActive { get; set; }
    public int NumberOfPositions { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ClosedOn { get; set; }
    [MaxLength(1000)]
    public string? ClosedReason { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    //Navigation property
    public JobRequirement? JobRequirement { get; set; }
}