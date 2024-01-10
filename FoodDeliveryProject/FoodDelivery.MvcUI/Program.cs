

using FoodDelivery.MvcUI.Areas.Admin.HttpApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // HttpContext.Session'ý kullanabilmek için ilgili servisi container a register etmeliyiz
builder.Services.AddHttpContextAccessor(); // Uygulama IHttpContextAccessor tipindeki bir nesnenin, istenilen alana inject edilebilmesi içincontainer a register etmemiz gerekiyor

builder.Services.AddHttpClient(); // HttpClient nesnesi isteyen yerlere bu nesneyi verebilmesi için
builder.Services.AddScoped<IHttpApiService, HttpApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Session'ý kullanabilmek için pipeline'a eklememiz gerekiyor

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "login",
//    pattern: "{controller=UserLogIn}/{action=LogIn}/{id?}");

app.MapAreaControllerRoute(
    name:"adminAreaDefault",
    areaName:"admin",
    pattern: "{area}/{controller=Authentication}/{action=LogIn}/{id?}"
  );


app.Run();
