using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApplicationCore.Entities;

public class Status
{
    public int Id { get; set; }
    public string StatusCode { get; set; }
    public string StatusDescription { get; set; }
    public List<Job> Jobs { get; set; }
}