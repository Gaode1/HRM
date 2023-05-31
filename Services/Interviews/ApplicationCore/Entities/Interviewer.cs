using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Interviewer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public Guid EmployeeId { get; set; }
    [Required] [StringLength(50)]public string FirstName { get; set; }
    [Required] [StringLength(50)]public string LastName { get; set; }
}