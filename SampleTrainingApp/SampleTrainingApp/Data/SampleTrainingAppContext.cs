using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleTrainingApp.Models;

namespace SampleTrainingApp.Data
{
    public class SampleTrainingAppContext : DbContext
    {
        public SampleTrainingAppContext (DbContextOptions<SampleTrainingAppContext> options)
            : base(options)
        {
        }

        public DbSet<SampleTrainingApp.Models.Inventory> Inventory { get; set; } = default!;
    }
}
