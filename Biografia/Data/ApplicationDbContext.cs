using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Biografia.Models;

namespace Biografia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Biografia.Models.Experiencia> Experiencia { get; set; }
        public DbSet<Biografia.Models.Educacao> Educacao { get; set; }
        public DbSet<Biografia.Models.Competencias> Competencias { get; set; }
        public DbSet<Biografia.Models.Treino> Treino { get; set; }
    }
}
