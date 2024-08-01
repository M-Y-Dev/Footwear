using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Services
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
        }
    }
}
