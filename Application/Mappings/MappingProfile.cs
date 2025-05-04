using ApplicationLayer.AuthCommand_Handler.AuthCommand;
using ApplicationLayer.DTOs;
using ApplicationLayer.MenuItemCommand_Query.MenuItemCommand;
using ApplicationLayer.OrderCommand_Query_Handler.OrderCommand;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using AutoMapper;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User ↔ Register/Login DTO
            CreateMap<RegisterDTO, RegisterCommand>();
            CreateMap<LoginDTO, LoginCommand>();
            CreateMap<User, RegisterDTO>().ReverseMap();

            // MenuItem ↔ DTOs
            CreateMap<MenuItem, MenuItemDTO>().ReverseMap();
            CreateMap<MenuItem, MenuItemCreateDTO>().ReverseMap();
            CreateMap<MenuItemDTO, CreateMenuItemCommand>().ReverseMap();
            CreateMap<MenuItemDTO, UpdateMenuItemCommand>().ReverseMap();

            // Order ↔ DTOs
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderDTO, CreateOrderCommand>().ReverseMap();
            CreateMap<OrderDTO, UpdateOrderCommand>().ReverseMap();

            // Review ↔ DTOs
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<ReviewDTO, CreateReviewCommand>().ReverseMap();
            CreateMap<ReviewDTO, UpdateReviewCommand>().ReverseMap();
        }
    }
}
