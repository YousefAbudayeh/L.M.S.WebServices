using L.M.S.Application.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.SetupServices();

builder.Services.SetupCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(StartupExtensions.AnyOriginPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();