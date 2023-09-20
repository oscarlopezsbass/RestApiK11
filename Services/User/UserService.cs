using Data;
using Data.Models;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService
    {

        public async Task<UserDtoResponse> GetUsers(int page, dataContext context)
        {

            var query = context.Users.AsQueryable();

            var totalItems = query.Count();

            List<UserModel> users = query
                .Skip((page - 1) * 5)
                .Take(5)
                .ToList();


            UserDtoResponse userResponse = new UserDtoResponse()
            {
                totalCount = totalItems,
                pageSize = 5,
                currentPage = page,
                totalPages = (int)Math.Ceiling((double)totalItems / 5),
                data = users
            };
            return userResponse;
        }

        public static UserDto GetUserById(int id, dataContext context)
        {

            UserDto userDto = new UserDto();

            var user = context.Users.Where(x => x.id == id).FirstOrDefault();
            userDto.id = user.id;
            userDto.email = user.email;
            userDto.first_name = user.first_name;
            userDto.last_name = user.last_name;
            userDto.avatar = user.avatar;

            return userDto;
        }

        public  async Task<UserModel> CreateUser(UserModel user, dataContext context)
        {

            context.Users.Add(user);
            await context.SaveChangesAsync();

           return user; ;
        }

        public async Task<UserModel> UpdateUser(int id, UserModel user, dataContext context)
        {

          
            var userfind = await context.Users.FindAsync(id);
            if (userfind == null) {
                return userfind; 
            }

            userfind.email = user.email;
            userfind.first_name = user.first_name;
            userfind.last_name = user.last_name;
            userfind.avatar = user.avatar;


            context.Entry(userfind).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return userfind;
        }
    }
}
