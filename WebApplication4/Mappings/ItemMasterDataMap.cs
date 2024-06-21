using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Mappings
{
    public class ItemMasterDataMap : IEntityTypeConfiguration<ItemMasterData>
    {
        public void Configure(EntityTypeBuilder<ItemMasterData> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.ItemCode).IsRequired();

        }
    }
}


