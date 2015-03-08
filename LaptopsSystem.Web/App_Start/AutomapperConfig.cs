using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using LaptopsSystem.Models;
//using LaptopsSystem.Web.Models;
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Models;
using LaptopsSystem.Web.Areas.Admin.Models;

namespace LaptopsSystem.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            #region Laptop

            Mapper.CreateMap<Laptop, LaptopIndex>()
                .ForMember(l => l.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer.Name));

            Mapper.CreateMap<Laptop, LaptopDetails>()
                .ForMember(l => l.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer.Name))
                .ForMember(l => l.Monitor, opt => opt.MapFrom(s => s.Monitor.Size))
                .ForMember(l => l.VotesCount, opt => opt.MapFrom(s => s.Votes.Count))
                .ForMember(l => l.Comments, opt => opt.MapFrom(s => s.Comments))
                .ForMember(l => l.HasVoted, opt => opt.Ignore());

            #endregion

            #region Comment

            Mapper.CreateMap<Comment, CommentInLaptop>()
                .ForMember(c => c.Author, opt => opt.MapFrom(s => s.Author.UserName));

            Mapper.CreateMap<CommentInput, Comment>();

            #endregion

            #region Manufacturer

            Mapper.CreateMap<Manufacturer, ManufacturerIndex>()
                .ForMember(m => m.LaptopModelsCount, opt => opt.MapFrom(s => s.Laptops.Count));

            Mapper.CreateMap<Manufacturer, ManufacturerInput>().ReverseMap();

            Mapper.CreateMap<Manufacturer, ManufacturerEdit>().ReverseMap();

            #endregion
        }
    }
}