using Microsoft.Extensions.Logging;
using POSServices.HttpApiManager;
using POSServices.Services.Authentication;
using POSServices.Services.Customers;
using POSServices.Services.Products;
using Radzen;

namespace Floorzap.POS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddRadzenComponents();
			builder.Services.AddHttpClient();

			builder.Services.AddSingleton<IApiManager, ApiManager>();
			builder.Services.AddTransient<IProductService, ProductService>();
			builder.Services.AddTransient<ICustomerService, CustomerService>();
			builder.Services.AddTransient<IAccountService, AccountService>();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
