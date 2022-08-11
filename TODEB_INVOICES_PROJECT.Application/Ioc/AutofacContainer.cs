using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;
using TODEB_INVOICES_PROJECT.Application.Services.Concrete;
using TODEB_INVOICES_PROJECT.Application.Services.Interface;
using TODEB_INVOICES_PROJECT.Application.Validations;

namespace TODEB_INVOICES_PROJECT.Application.Ioc
{
    public class AutofacContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            builder.RegisterType<LoginValidation>().As<IValidator<LoginDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterDTO>>().InstancePerLifetimeScope();
        }
    }
}
