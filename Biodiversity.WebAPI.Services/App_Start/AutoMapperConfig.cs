using AutoMapper;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.WebAPI.Services.Models.Author;

namespace Biodiversity.WebAPI.Services
{
    public class AutoMapperConfig
    {
        public static void RegisterTypes()
        {
            Mapper.CreateMap<Author, AuthorListModel>()
                .ForMember(s => s.AuthorId, t => t.MapFrom(u => u.AuthorId))
                .ForMember(s => s.LastName, t => t.MapFrom(u => u.LastName))
                .ForMember(s => s.FirstName, t => t.MapFrom(u => u.FirstName))
                .ForMember(s => s.Abbreviation, t => t.MapFrom(u => u.Abbreviation))
                .ForMember(s => s.Comment, t => t.MapFrom(u => u.Comment))
                .ForMember(s => s.SurName, t => t.MapFrom(u => u.SurName))
                .ForMember(s => s.CreatedBy, t => t.MapFrom(u => u.CreatedBy))
                .ForMember(s => s.CreatedDate, t => t.MapFrom(u => u.CreatedDate))
                .ForMember(s => s.ModifiedBy, t => t.MapFrom(u => u.ModifiedBy))
                .ForMember(s => s.ModifiedDate, t => t.MapFrom(u => u.ModifiedDate));
            Mapper.AssertConfigurationIsValid();
        }
    }
}