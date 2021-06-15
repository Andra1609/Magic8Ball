using FrontEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor chaining
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Response> Response { get; set; }
    }
}
