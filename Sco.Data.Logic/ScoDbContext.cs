using Microsoft.EntityFrameworkCore;
using Sco.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sco.Data.Logic
{
    public partial class ScoDbContext : DbContext
    {
        public ScoDbContext()
        { }

        public ScoDbContext(DbContextOptions<ScoDbContext> options)
    : base(options)
        { }

        public virtual DbSet<scouser> scousers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
