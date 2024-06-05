using Sort.Logic;
using Sort.Reader;

namespace Sort
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IXmlReader, XmlReader>();
            builder.Services.AddScoped<ISortMethod, SortMethod>();

            return builder.Build();
        }


        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            app.Run();
            return app;
        }

    }
}
