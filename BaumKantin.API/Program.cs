using BaumKantin.Core.Repositories;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;
using BaumKantin.Repository.Repositories;
using BaumKantin.Repository.UnitOfWorks;
using BaumKantin.Service.Mapping;
using BaumKantin.Service.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IRoomRepository,RoomRepository>();
builder.Services.AddScoped<IRoomService,RoomService>();
builder.Services.AddScoped<IImageRepository,ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));
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
