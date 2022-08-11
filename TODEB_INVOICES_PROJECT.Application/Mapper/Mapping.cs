using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;

namespace TODEB_INVOICES_PROJECT.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<User, EditProfileDTO>().ReverseMap();

        }
    }
}
