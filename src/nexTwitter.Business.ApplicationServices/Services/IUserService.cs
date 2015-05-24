using nexTwitter.Business.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexTwitter.Business.ApplicationServices.Services
{
    public interface IUserService
    {
        UserDTO GetById(int id);
    }
}
