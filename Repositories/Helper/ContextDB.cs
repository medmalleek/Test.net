using MODULES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace REPOSITORIES.Helper
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options) { }
        public DbSet<TaskModule> TaskModules { get; set; }
    }
}
