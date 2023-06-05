using AAB_KATM_SERVER.DTOs.Clients;
using AAB_KATM_SERVER.Entities;
using AutoMapper;

namespace AAB_KATM_SERVER.Configuration.Mapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
            
            CreateMap<Client, ClientUpdateDTO>();

            CreateMap<ClientUpdateDTO, Client>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
