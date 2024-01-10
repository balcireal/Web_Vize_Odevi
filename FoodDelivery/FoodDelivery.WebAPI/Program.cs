using FoodDelivery.Business;
using WS.WebAPI.Middlewares;

namespace FoodDelivery.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddApiService(builder.Configuration);
            builder.Services.AddBusinessServices();



            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            // a�a��daki 2 middleware [Authorize] attribute unun �al��abilmesi i�in mutlaka eklenmeli.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();

            app.Run();
        }
    }
}