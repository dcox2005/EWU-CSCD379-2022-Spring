<<<<<<< HEAD
<<<<<<< HEAD
=======
using Wordle.api.Services;
=======
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Services;
>>>>>>> remotes/Intellitect-Spring/main

>>>>>>> 6aeb3a19b05d7c718c0c0cac35382d6e5af6b464
var builder = WebApplication.CreateBuilder(args);

//Change CORS policy

string allowance = "AllowAll";

var allowAll = builder.Services.AddCors(options => {
    options.AddPolicy(allowance, builder => 
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
<<<<<<< HEAD
=======
builder.Services.AddScoped<ILeaderBoardService, LeaderBoardServiceMemory>();
>>>>>>> 6aeb3a19b05d7c718c0c0cac35382d6e5af6b464

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ScoreStatsService>();

var app = builder.Build();

//Create database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    ScoreStatsService.Seed(context);
}
// Configure the HTTP request pipeline.
<<<<<<< HEAD
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
=======
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
>>>>>>> 6aeb3a19b05d7c718c0c0cac35382d6e5af6b464

app.UseHttpsRedirection();

app.UseCors(allowance);

app.UseAuthorization();

app.MapControllers();

app.Run();
