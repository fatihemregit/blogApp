using BlogApp.Utils.Extensions;
using BlogApp.Utils.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Data Extensions
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.setInterfaceConcretesForDataLayer();
//Business Extensions
builder.Services.setInterfaceConcretesForBusinessLayer();

//Main Extensions
builder.Services.SetAuthentication();
builder.Services.ConfigureCookie();
builder.Services.setAutoMapperForMainLayer();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}");

app.Run();
