using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class RecruitingDbContext: DbContext
{
    //need to inject DbContextOptions to the ctor -> go to program.cs to do DI
    public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options): base(options)
    {
         
    }
    //
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Employee> Type { get; set; }
    public DbSet<Submission> Submissions { get; set; }
}  