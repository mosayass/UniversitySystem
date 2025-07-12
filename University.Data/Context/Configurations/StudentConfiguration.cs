using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Data.Entities;

namespace University.Data.Context.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("StudnetId");
            builder.Property(t=>t.Name).HasMaxLength(256);
        }
    }
}
