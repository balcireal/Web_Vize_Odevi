using FoodDelivery.Business.Implementations;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.Business.Profiles;
using FoodDelivery.DataAccess.EF.Repositories;
using FoodDelivery.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDelivery.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AddressProfile));

            services.AddScoped<IAddressBs, AddressBs>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICountryBs, CountryBs>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddScoped<ICustomerBs, CustomerBs>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICustomerAddressBs, CustomerAddressBs>();
            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();

            services.AddScoped<IDeliveryDriverBs, DeliveryDriverBs>();
            services.AddScoped<IDeliveryDriverRepository, DeliveryDriverRepository>();

            services.AddScoped<IFoodOrderBs, FoodOrderBs>();
            services.AddScoped<IFoodOrderRepository, FoodOrderRepository>();

            services.AddScoped<IOrderProductBs, OrderProductBs>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();

            services.AddScoped<IOrderStatusBs, OrderStatusBs>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();

            services.AddScoped<IProductBs, ProductBs>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IRestaurantBs, RestaurantBs>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.AddScoped<IAdminUserBs, AdminUserBs>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        }
    }
}
