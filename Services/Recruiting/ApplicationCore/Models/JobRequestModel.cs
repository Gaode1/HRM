using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int  Id { get; set; }
    
    [Required(ErrorMessage = "Please input title")]
    [StringLength(128)]
    public string Title { get; set; }
    [Required(ErrorMessage = "Please input Description")]
    [StringLength(1024)]
    public string Description { get; set; }
    [Required(ErrorMessage = "Please input date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "Please input Description")]
    public int NumOfPositions { get; set; }
}