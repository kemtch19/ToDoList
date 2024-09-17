using ToDoList.Data;
using ToDoList.Services.Interface;
using ToDoList.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add the services for controllers
builder.Services.AddControllers();

//Service to MongoDb
builder.Services.AddSingleton<MongoDbContext>();

//Service for the cors middleware
builder.Services.AddCors(Options=>{
    Options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

//Services to Interface and Repository
builder.Services.AddScoped<ITareaRepository, TareaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// use for the service of cors
app.UseCors("AllowAnyOrigin");

//Controllers
app.MapControllers();

app.Run();