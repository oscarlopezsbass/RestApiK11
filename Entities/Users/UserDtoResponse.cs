using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class UserDtoResponse
    {
       public int totalCount { get; set; }
       public int pageSize { get; set; }
       public int currentPage { get; set; }
       public int totalPages { get; set; }
       public List<UserModel> data { get; set; }
    }
}
