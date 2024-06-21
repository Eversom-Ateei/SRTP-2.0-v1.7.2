using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Mappings
{
    public class MaterialInspectLinesMap : IEntityTypeConfiguration<MaterialInspectLine>
    {
        public void Configure(EntityTypeBuilder<MaterialInspectLine> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.Id).IsRequired();

        }
    }
}


