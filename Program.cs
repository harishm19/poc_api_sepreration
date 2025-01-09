using POC_employee_Dpt.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Register the EmployeeService with dependency injection (DI)
//builder.Services.AddSingleton<EmployeeService>(provider =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("EmployeeManagementDb");
//    return new EmployeeService(connectionString);
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optionally, enable CORS (if needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
