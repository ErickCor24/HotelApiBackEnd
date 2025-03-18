using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HotelApi.Service.Customer;
using HotelApi.Service.Employee;
using HotelApi.Service.Room;
using HotelApi.Service.RoomType;
using HotelApi.Service.Reservation;
using HotelApi.Service.Invoice;

var builder = WebApplication.CreateBuilder(args);

// Add connection with DataBase
var CONNECTION_STRING = builder.Configuration.GetConnectionString("HotelDB");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(CONNECTION_STRING));

// Add service layer
builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IRoomService, RoomServiceImpl>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeServiceImpl>();
builder.Services.AddScoped<IReservationService, ReservationServiceImpl>();
builder.Services.AddScoped<IInvoiceService, InvoiceServiceImpl>();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurate CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
