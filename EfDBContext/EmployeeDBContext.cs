using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDBContext
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Template> Template { get; set; }

        public virtual DbSet<TemplateStatus> TemplateStatus { get; set; }
    }
}
