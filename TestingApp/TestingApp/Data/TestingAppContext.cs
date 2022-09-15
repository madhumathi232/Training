using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingApp.Models;

namespace TestingApp.Data
{
    public class TestingAppContext : DbContext
    {
        public TestingAppContext (DbContextOptions<TestingAppContext> options)
            : base(options)
        {
        }

        public DbSet<TestingApp.Models.MyDetails> MyDetails { get; set; } = default!;
    }
}
