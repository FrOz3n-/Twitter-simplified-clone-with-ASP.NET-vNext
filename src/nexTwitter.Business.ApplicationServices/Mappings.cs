using nexTwitter.Business.ApplicationServices.DTOs;
using nexTwitter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace nexTwitter.Business.ApplicationServices
{
    public class Mappings
    {
        public static void DefineMappings()
        {
            Mapper.CreateMap<User, UserDTO>();
        }
    }
}
