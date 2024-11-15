using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using QLNH_Web_APIs.Models;
using QLNH_Web_APIs.DTOs;

namespace QLNH_Web_APIs.Mappings
{
    public class MappingProfile : Profile // kế thừa từ thư viện AutoMapper
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            // như này User đã che giấu được password
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
            // .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser));

            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));

            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));

            CreateMap<Guest, GuestDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));

            CreateMap<Status, StatusDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));


        }
    }
}

// A là tài sản chính - không muốn show ra cho thiên hạ thấy -> tạo ra lớp B nhầm che giấu A -> B
// CreateMap<A, B>
// dest là từng tài sản của A muốn cho mọi người thấy
// src là tài sản quyết định sẽ được công bố cho dự luận biết