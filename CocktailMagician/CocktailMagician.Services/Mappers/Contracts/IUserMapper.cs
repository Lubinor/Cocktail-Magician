using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface IUserMapper
    {
        public UserDTO MapToUserDTO(User user);
        public User MapToUser(UserDTO userDTO);
    }
}
