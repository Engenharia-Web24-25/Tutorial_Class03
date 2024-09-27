using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Class03.Models;

namespace Class03.Data
{
    public class Class03Context : DbContext
    {
        public Class03Context(DbContextOptions<Class03Context> options)
            : base(options)
        {
        }

        public DbSet<Class03.Models.Category> Category { get; set; } = default!;
    }
}
