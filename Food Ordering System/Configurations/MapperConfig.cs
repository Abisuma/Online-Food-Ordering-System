using AutoMapper;
using Models;
using Models.DTOs.Menu;
using Models.DTOs.Order;
using Models.DTOs.Restaurant;
using Models.DTOs.User;

namespace Food_Ordering_System.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
                //Restaurant mapping
                CreateMap<Restaurant, CreateRestaurantDTO>().ReverseMap();
                CreateMap<Restaurant, GetRestaurantDTO>().ReverseMap(); 
                CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
                CreateMap<Restaurant, UpdateRestaurantDTO>().ReverseMap(); 

                //Menu mapping

               CreateMap<Menu, MenuDTO>().ReverseMap();
           
               CreateMap<Menu, BaseMenuDTO>().ReverseMap();

              
            //user mapping
            CreateMap<APIUser, APIUserDto>().ReverseMap();

            //order mapping
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, BaseOrderDTO>().ReverseMap();
            //CreateMap<OrderDTO, BaseOrderDTO>().ReverseMap(); 

        }
    }
}
