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
            Mapper.CreateMap<CoordinatesViewModel,Coordinate>().ReverseMap();
            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            Mapper.CreateMap<Student, ApplicationUserViewModel>().ReverseMap();
            Mapper.CreateMap<Teacher, ApplicationUserViewModel>().ReverseMap();
            Mapper.CreateMap<Group, GroupViewModel>().ReverseMap();
            Mapper.CreateMap<Event, EventViewModel>().ReverseMap();
        }
    }
}