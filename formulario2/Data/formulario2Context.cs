using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using formulario2.Models;

namespace formulario2.Data
{
    public class formulario2Context : DbContext
    {
        public formulario2Context (DbContextOptions<formulario2Context> options)
            : base(options)
        {
        }

        public DbSet<formulario2.Models.membro> membro { get; set; } = default!;
    }
}
