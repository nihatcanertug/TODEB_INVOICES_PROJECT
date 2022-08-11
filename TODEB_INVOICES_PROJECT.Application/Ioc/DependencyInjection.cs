using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Mapper;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;
using TODEB_INVOICES_PROJECT.Application.Services.Concrete;
using TODEB_INVOICES_PROJECT.Application.Services.Interface;
using TODEB_INVOICES_PROJECT.Application.Validations;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Domain.UnitOfWork;
using TODEB_INVOICES_PROJECT.Infrastructure.Context;
using TODEB_INVOICES_PROJECT.Infrastructure.UnitOfWork;

namespace TODEB_INVOICES_PROJECT.Application.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            //resolve
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();

            //Validation Resolver
            services.AddTransient<IValidator<RegisterDTO>, RegisterValidation>();
            services.AddTransient<IValidator<LoginDTO>, LoginValidation>();

            //"AddIdentity" sınıfı için Microsoft.AspNetCore.Identity paketi indirilir.
            services.AddIdentity<User,UserPassword>(x => {
                x.SignIn.RequireConfirmedAccount = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.User.RequireUniqueEmail = false;
                x.Password.RequiredLength = 3;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
            });

            return services;
        }
    }
}
