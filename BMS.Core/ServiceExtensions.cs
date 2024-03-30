using BMS.Core.Contracts;
using BMS.Core.Services;
using BMS.Domain.Contracts;
using BMS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BMS.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreService(this IServiceCollection services)
        {
            services.AddScoped<IBookCateoryService, BookCategoryService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
