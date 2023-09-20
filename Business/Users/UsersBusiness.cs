using Data;
using Data.Models;
using Entities.Users;
using Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users
{
    public class UsersBusiness
    {

        public async Task<UserDtoResponse> GetUsers(int page, dataContext context)
        {

            UserService userService = new UserService();

            UserDtoResponse response = await userService.GetUsers(page, context);

            return response;
        }

        public async Task<UserDto>GetUser(int id, dataContext context)
        {

            UserService userService = new UserService();

            UserDto response = UserService.GetUserById(id, context);

            return response;
        }
        public async Task<UserModel> CreateUser(UserModel user, dataContext context)
        {

            UserService userService = new UserService();

            var response = await userService.CreateUser(user, context);

            return response;
        }
        public async Task<UserModel> UpdateUser(int id, UserModel user, dataContext context)
        {

            UserService userService = new UserService();

            var response = await userService.UpdateUser(id, user, context);

            return response;
        }
    }

}
