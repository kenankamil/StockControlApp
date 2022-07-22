using AutoMapper;
using Kenan.CodeBaseCodeChallange.Business.Helpers;
using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.Business.Services;
using Kenan.CodeBaseCodeChallange.DataAccess.Contexts;
using Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork;
using Kenan.CodeBaseCodeChallange.UI.Mapping.AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<ProductContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
}
);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSaleService, ProductSaleService>();

builder.Services.AddScoped<IUoW, UoW>();

var profiles = ProfileHelper.GetProfiles();
profiles.Add(new ProductProfile());
profiles.Add(new ProductSaleProfile());

var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=ListProduct}/{id?}");

app.Run();
