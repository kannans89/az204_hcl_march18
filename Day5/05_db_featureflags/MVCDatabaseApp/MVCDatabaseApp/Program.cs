using Microsoft.FeatureManagement;
using MVCDatabaseApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfigConnectionString");

builder.Host.ConfigureAppConfiguration(builder =>
{

    //Connect to your App Config Store using the connection string
    builder.AddAzureAppConfiguration(options =>
                    options.Connect(connectionString).UseFeatureFlags());
});



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddFeatureManagement();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
