var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<ILinkShortnerService, LinkShortnerService>();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAllOrigins",
      builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
