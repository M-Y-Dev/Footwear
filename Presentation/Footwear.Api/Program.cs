using Footwear.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Footwear.Application.Services;
using Footwear.Application.Interfaces;
using Footwear.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FootwearContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatorService();
builder.Services.AddAutoMapperService();
builder.Services.AddFluentValidationServices();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRespository, ProductRespository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
