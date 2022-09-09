using CardApp.Server.Bll.Domain;
using CardApp.Server.Bll.Interfaces;
using CardApp.Server.Dal.Interfaces;
using CardApp.Server.Dal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbPath = builder.Configuration["DbPath"] ?? "db.json";
builder.Services.AddSingleton<ICardInfoRepository>(new DefaultCardInfoRepository(dbPath));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ICardInfoService>(new DefaultCardService(builder.Services.BuildServiceProvider().GetService<ICardInfoRepository>()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();


var app = builder.Build();

app.MapHealthChecks("/health");

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