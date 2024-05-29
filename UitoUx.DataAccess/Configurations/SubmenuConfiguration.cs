using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UitoUx.Domain.Models;

namespace UitoUx.DataAccess.Configurations
{
    public class SubmenuConfiguration : IEntityTypeConfiguration<SupMenu>
    {
        public void Configure(EntityTypeBuilder<SupMenu> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.HeaderId).IsRequired();
            builder.Property(x => x.SubMenuName).IsRequired();

        }
    }
}
