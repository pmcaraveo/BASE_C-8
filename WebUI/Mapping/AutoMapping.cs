using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TDJ.WebUI.ViewModels;
using TDJ.WebUI.Models;
using TSJ.Domain;

namespace TDJ.WebUI.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserVm, ViewUserRol>().ReverseMap();
            CreateMap<MenuVm, Menu>().ReverseMap();
            //CreateMap<InicioDemandaVm, InicioDemanda>().ReverseMap();
        }
    }
}
