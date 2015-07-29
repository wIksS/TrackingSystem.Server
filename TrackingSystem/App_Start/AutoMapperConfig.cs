using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackingSystem.Models;
using TrackingSystem.ViewModels;

namespace TrackingSystem.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<CoordinatesViewModel,Coordinate>();
        }
    }
}