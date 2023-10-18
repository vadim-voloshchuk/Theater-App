using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMVCapp.Models;

namespace MyMVCapp.Data
{
    public class MyMVCappContext : DbContext
    {
        public MyMVCappContext (DbContextOptions<MyMVCappContext> options)
            : base(options)
        {
        }

        public DbSet<MyMVCapp.Models.Spectacle> Spectacle { get; set; } = default!;
    }
}
