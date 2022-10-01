var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string eShopConnectionString = builder.Configuration.GetConnectionString("EShop");
string eShopQueryConnectionString = builder.Configuration.GetConnectionString("EShopQuery");

ShopManagement.Infrastructure.Core.Bootstrapper.Config(builder.Services, eShopConnectionString);
DiscountManager.Infrastructure.Core.Bootstrapper.Config(builder.Services, eShopConnectionString);
InventoryManager.Infrastructure.Core.Bootstrapper.Config(builder.Services, eShopConnectionString);
EShopQuery.Bootstrapper.Config(builder.Services);
SecondaryDB.Infrastructure.Core.Bootstrapper.Config(builder.Services, eShopQueryConnectionString);
DocumentManager.Infrastructures.AspBootstrapper.Config(builder.Services);

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
