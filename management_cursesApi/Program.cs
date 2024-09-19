using management_cursesDL.EF.Contexts;
using managmant_cursesEntitis;
using Microsoft.EntityFrameworkCore;
using management_cursesBL.Interface;
using management_cursesDL.Interface;

using management_cursesDL.service;
using management_cursesDL.EF.Models;
using management_cursesBL.service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//--
builder.Services.AddScoped<IUserDL, UserDL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.Configure<AppSettings>(builder.Configuration);//בשביל שיהיה אפשר להשתמש אם זה במהלך הפרויקט
AppSettings appSetting = builder.Configuration.Get<AppSettings>();//צורה יחודית כדי שיוכלו להשתמש בדף הזה(בשביל ההתחברות ל


builder.Services.AddDbContext<CoursesManagementContext>(o =>
{
    o.UseSqlServer(appSetting.ConnectionStrings.ManagmentCurses);
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
