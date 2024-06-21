using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Mappings;
using WebApplication4.Models;

namespace WebApplication4.Context
{
    public class TemplateContext : DbContext
    {
        #region 1
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options) { }

        #region "DBSets"
        public DbSet<User> Users { get; set; }
        public DbSet<ProductInspect> ProductInspects { get; set; }
        public DbSet<MaterialInspect> MaterialInspects { get; set; }
        public DbSet<MaterialInspectLine> MaterialInspectLines { get; set; }
        public DbSet<ReceiptOfGoods> ReceiptOfGoods { get; set; }
        public DbSet<BlockReason> BlockReasons { get; set; }
        #endregion
        public DbSet<ItemMasterData> ItemMasterDatas { get; set; }
        public DbSet<ProductionSetup> ProductionSetups { get; set; }
        public DbSet<ProductionSetupLine> ProductionSetupLines { get; set; }


        public DbSet<ProductionTool> ProductionTools { get; set; }
        public DbSet<ProductionFlaw> ProductionFlaws{ get; set; }
        #endregion  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductInspectMap());
            modelBuilder.ApplyConfiguration(new MaterialInspectMap());
            modelBuilder.ApplyConfiguration(new MaterialInspectLinesMap());
            modelBuilder.ApplyConfiguration(new BlockReasonMap());
            modelBuilder.ApplyConfiguration(new ReceiptOfGoodsMap());
            modelBuilder.ApplyConfiguration(new ItemMasterDataMap());
            modelBuilder.ApplyConfiguration(new ProductionSetupMap());
            modelBuilder.ApplyConfiguration(new ProductionSetupLineMap());
            modelBuilder.ApplyConfiguration(new ProductionToolMap());
            modelBuilder.ApplyConfiguration(new ProductionFlawMap());




      

            base.OnModelCreating(modelBuilder);

        }


    }
}