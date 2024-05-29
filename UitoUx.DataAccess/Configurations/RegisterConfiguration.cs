using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UitoUx.Domain.Models;

namespace UitoUx.DataAccess.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MiddelName).HasMaxLength(50);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password);
            builder.Property(x => x.ConfirmPassword);



        }
    }
}
