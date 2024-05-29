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
    public class HederMenuConfiguration : IEntityTypeConfiguration<HederMenu>
    {
        public void Configure(EntityTypeBuilder<HederMenu> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.HederName).IsRequired();

            builder.HasMany(x => x.SupMenus)
                    .WithOne(x => x.HederMenu)
                    .HasForeignKey(x => x.HeaderId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
