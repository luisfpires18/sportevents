using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using tinc.Business;
using tinc.Domain.Interfaces.Manager;
using tinc.Domain.Interfaces.Repository;
using tinc.Repository;
//using Swashbuckle.AspNetCore.Swagger;

namespace tinc.Web.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterServicesForStartup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {

            services.AddMvcCore().AddJsonOptions(opt =>
            {
                var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver == null) return;
                var res = resolver as DefaultContractResolver;
                if (res != null) res.NamingStrategy = null;  // <<!-- this removes the camelcasing
            });

            services.AddMvcCore().AddApiExplorer();

            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Fastest);
            //services.AddResponseCompression(options =>
            //{
            //    options.EnableFotincttps = true;
            //});

            //Repository.Dapper.Context.RepositoryContext.Instance.ConnectionString = connectionString;


            services.AddTransient<ISportManager, SportManager>();
            services.AddTransient<ISportRepository, SportRepository>();


            //services.AddTransient<IMessageRepository, MessageRepository>();

            //services.AddTransient<IDeviceManager, DeviceManager>();
            //services.AddTransient<IDeviceRepository, DeviceRepository>();

            ////As this is not a dbcontext we must add this
            //Repository.Json.Context.RepositoryContext.Instance.ConnectionString =
            //    Path.Combine(Directory.GetCurrentDirectory(), "files");
            //services.AddTransient<IAppRepository, Repository.Json.AppRepository>();
            //services.AddTransient<IQuickAccessMenuRepository, Repository.Json.QuickAccessMenu>();
            //services.AddTransient<IBrandRepository, Repository.Json.BrandRepository>();



            //services.AddTransient<IAppManager, AppManager>();
            //services.AddTransient<IVehiclesManager, VehiclesManager>();
            //services.AddTransient<ICampaignManager, CampaignManager>();
            //services.AddTransient<ICampaignRepository, CampaignRepository>();

            //services.AddTransient<IContactManager, ContactManager>();

            //services.AddTransient<ICustomerManager, CustomerManager>();
            //services.AddTransient<IVehiclesRepository, VehiclesRepository>();

            //services.AddScoped<TokenValidationAsyncResourceFilter>();
            //services.AddScoped<CurrentUserAsyncResourceFilter>();
            //services.AddScoped<CurrentJwtUserEmailAsyncResourceFilter>();





            services.ConfigureSwaggerGen(options =>
            {
                //options.(new Info
                //{
                //    Version = "v1",
                //    Title = "Salvador Caetano App Services Platform",
                //    Description = "",
                //    TermsOfService = "None",
                //    Contact = new Contact() { Name = "Cristovão Morgado", Email = "cristovao.morgado@itsector.pt", Url = "www.itsector.com" }
                //});



                // var xmlPath = System.IO.Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "sc.Services.xml");
                // options.IncludeXmlComments(xmlPath);
            });

        }


    }
}
