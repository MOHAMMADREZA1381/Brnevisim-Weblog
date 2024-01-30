using Application.Interfaces;
using Application.SenderEmail;
using Application.Services;
using Domain.IRepositories;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices( IServiceCollection services)
        {
            //    <---Application LAYER--->
            services.AddScoped<IRenderService, RenderViewToString>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //    <---Data Layer --->
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();


        }
    }
}
