using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjetoSTI3.Data;
using ProjetoSTI3.Repository;
using ProjetoSTI3.Repository.Interface;
using ProjetoSTI3.Services;
using ProjetoSTI3.Services.Interface;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IgrejaBatistaContextConnection") ?? throw new InvalidOperationException("Connection string 'IgrejaBatista1ContextConnection' not found."); ;

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
builder.Services.AddMvc();

builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

builder.Services.AddTransient<IPedidoService, PedidoService>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

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
