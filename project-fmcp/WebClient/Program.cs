using Bussiness.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<SqliteContext>(options => options.UseSqlite("Data Source=D:/Faculta/Master/sem3/fmcp/project-fmcp/project-fmcp/Data/inventory.db"));

builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IRepositoryWarehouse, RepositoryWarehouse>();
builder.Services.AddScoped<IRepositoryInventoryRecord, RepositoryInventoryRecord>();

builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceWarehouse, ServiceWarehouse>();
builder.Services.AddScoped<IServiceInventory, ServiceInventory>();



var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();