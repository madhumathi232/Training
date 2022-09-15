using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthorService.Models;

namespace AuthorService.Data
{
    public class AuthorServiceContext : DbContext
    {
        public AuthorServiceContext (DbContextOptions<AuthorServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AuthorService.Models.UserTable> UserTable { get; set; } = default!;

        public DbSet<AuthorService.Models.Book>? Book { get; set; }
    }
}
