using AutoMapper;
using GestionForrajeria.Entities;
using GestionForrajeria.ViewModels.Mercaderia;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.MapperProfile
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Mercaderia, MercaderiaIndexViewModel>();
        }
    }
}
