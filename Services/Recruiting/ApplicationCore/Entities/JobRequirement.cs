namespace ApplicationCore.Entities;

public class JobRequirement
{
    public int Id { get; set; }
    public string language { get; set; }
    public int yoe { get; set; }
    public string location { get; set; }
    public int? JobId { get; set; }
    public Job? Job { get; set; }
}