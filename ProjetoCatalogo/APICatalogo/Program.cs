using APICatalogo.Context;
using APICatalogo.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configure Db.

builder.Services.AddDbContext<AppDbContext>(options => {
    // options.UseSqlServer("Server=localhost,1433;Database=CodigoDeAutorizacao;User Id=sa;Password=1q2w3e4r@#$;Trust Server Certificate=True;");
    options.UseSqlServer("Data Source=LENILSONNOTE\\SQLEXPRESS;Initial Catalog=CatalogoDB;Integrated Security=True;Trust Server Certificate=True;");

});


// Add services to the container.

builder.Services.AddControllers()
      .AddJsonOptions(options =>
         options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
