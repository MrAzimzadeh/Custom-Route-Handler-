using CustomRouteHandler.Handlers;

namespace CustomRouteHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            //app.Map("example-route" , async c =>
            //{
            //    // https://Example-route gelen butun istek qeyd olunan fonksiyona aktailacak ve oradan qarsilanacaq 
            //});


            app.Map("image/{imageName}" , new  ImageHandler().Handler(builder.Environment.WebRootPath));


            app.Map("example-route", new ExampleHandler().Handler()); // https://localhost:7128/example-route


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}