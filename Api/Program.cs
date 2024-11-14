using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod() 
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddDbContext<DBContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnectionString"),
        x => x.MigrationsAssembly("Infra")
    )
);

builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
