<<<<<<< HEAD
=======
using Wordle.api.Services;

>>>>>>> 6aeb3a19b05d7c718c0c0cac35382d6e5af6b464
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
<<<<<<< HEAD
=======
builder.Services.AddScoped<ILeaderBoardService, LeaderBoardServiceMemory>();
>>>>>>> 6aeb3a19b05d7c718c0c0cac35382d6e5af6b464

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
