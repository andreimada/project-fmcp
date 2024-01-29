using Bussiness.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SqliteContext>(options => options.UseSqlite("Data Source=D:/Faculta/Master/sem3/fmcp/project-fmcp/project-fmcp/Data/inventory.db"));

builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IRepositoryWarehouse, RepositoryWarehouse>();
builder.Services.AddScoped<IRepositoryInventoryRecord, RepositoryInventoryRecord>();

builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceWarehouse, ServiceWarehouse>();
builder.Services.AddScoped<IServiceInventory, ServiceInventory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();