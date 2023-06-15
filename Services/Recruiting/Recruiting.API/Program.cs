using System.Text;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

builder.Services.AddScoped<IBaseRepository<Job>, BaseRepository<Job>>();
builder.Services.AddScoped<IBaseRepository<Candidate>, BaseRepository<Candidate>>();
builder.Services.AddScoped<IBaseRepository<Submission>, BaseRepository<Submission>>();

builder.Services.AddScoped<IBaseService<Submission>, BaseService<Submission>>();
builder.Services.AddScoped<IBaseService<Job>, BaseService<Job>>();
builder.Services.AddScoped<IBaseService<Candidate>, BaseService<Candidate>>();



//Inject our connectionString into DbContext
builder.Services.AddDbContext<RecruitingDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection")));



//add jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme  )
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "HRM",
            ValidAudience = "HRM Users",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
        };
    } );

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


var angularURL = Environment.GetEnvironmentVariable("angularURL");

app.UseCors(policy =>
{
    policy.WithOrigins("angularURL").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});

app.MapControllers();

app.Run();