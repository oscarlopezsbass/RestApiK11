using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions options) : base(options) { }
        public DbSet<UserModel> Users{ get; set; }
    }
}
