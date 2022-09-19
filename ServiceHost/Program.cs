var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string connectionString = builder.Configuration.GetConnectionString("sql");

ShopManagement.Infrastructure.Core.Bootstrapper.Config(builder.Services, connectionString);
DiscountManager.Infrastructure.Core.Bootstrapper.Config(builder.Services, connectionString);
InventoryManager.Infrastructure.Core.Bootstrapper.Config(builder.Services, connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
