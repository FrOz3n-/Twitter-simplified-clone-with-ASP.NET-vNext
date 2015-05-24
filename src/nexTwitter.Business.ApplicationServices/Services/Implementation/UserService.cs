using AutoMapper;
using nexTwitter.Business.ApplicationServices.DTOs;
using nexTwitter.Domain.Entities;
using nexTwitter.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexTwitter.Business.ApplicationServices.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ICommonRepository _repository;
        public UserService(ICommonRepository repository)
        {
            _repository = repository;
        }
        public UserDTO GetById(int id)
        {
            return Mapper.Map<UserDTO>(_repository.GetById<User>(id));
        }
    }
}
