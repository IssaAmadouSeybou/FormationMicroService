using Mango.web.Controllers;
using Mango.web.Service;
using Mango.web.Service.IService;
using Mango.web.Utulity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
#pragma warning disable CS8601 // Existence possible d'une assignation de référence null.
SD.CouponApiBase = builder.Configuration["ServiceUrls:CouponAPI"];
#pragma warning restore CS8601 // Existence possible d'une assignation de référence null.
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService,CouponService>();
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
