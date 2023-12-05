using AutoMapper;
using GreatOnion.Application.DTOClasses;
using GreatOnion.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.InnerInfrastructure.Mappings
{
    public class DTOMapProfile:Profile
    {
       
        public DTOMapProfile()
        {
            #region ProductDTOMapping
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitPrice,act => act.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.CategoryID,act => act.MapFrom(src=> src.CategoryID))
                .ForMember(dest => dest.CreatedDate,act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate,act => act.MapFrom(src=>src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate,act => act.MapFrom(src=> src.DeletedDate))
                .ReverseMap();
            #endregion


            #region CategoryDTOMapping

            CreateMap<Category,CategoryDTO>()
                .ForMember(dest => dest.CategoryName,act => act.MapFrom(src=> src.CategoryName))
                .ForMember(dest => dest.Description,act => act.MapFrom(src=> src.Description))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate, act => act.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate, act => act.MapFrom(src => src.DeletedDate))
                .ReverseMap();
            #endregion

            #region OrderDTOMapping
            CreateMap<Order,OrderDTO>()
                .ForMember(dest => dest.ShippedAddress, act => act.MapFrom(src=> src.ShippedAddress))
                .ForMember(dest=> dest.AppUserID, act => act.MapFrom(src => src.AppUserID))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate, act => act.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate, act => act.MapFrom(src => src.DeletedDate))
                .ReverseMap();
            #endregion

            #region OrderProductDTOMapping

            CreateMap<OrderProduct,OrderProductDTO>()
                .ForMember(dest => dest.OrderID,act => act.MapFrom(src=> src.OrderID))
                .ForMember(dest => dest.ProductID,act=> act.MapFrom(src =>src.ProductID))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate, act => act.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate, act => act.MapFrom(src => src.DeletedDate))
                .ReverseMap();
            #endregion

            #region AppUserDTOMapping

            CreateMap<AppUser,AppUserDTO>()
                .ForMember(dest => dest.UserName,act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserPassword,act => act.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate, act => act.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate, act => act.MapFrom(src => src.DeletedDate))
                .ReverseMap();
            #endregion

            #region UserProfileDTOMapping

            CreateMap<UserProfile, UserProfileDTO>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.ModifiedDate, act => act.MapFrom(src => src.ModifiedDate))
                .ForMember(dest => dest.DeletedDate, act => act.MapFrom(src => src.DeletedDate))
                .ReverseMap();
            #endregion


        }


    }
}
