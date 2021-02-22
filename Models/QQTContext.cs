using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace NetCoreMixProject.Models
{
    public partial class QQTContext : DbContext
    {
        public QQTContext()
        {
        }

        public QQTContext(DbContextOptions<QQTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerProductBuyLog> CustomerProductBuyLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationSection section = ConfigHelper.Get("QQTConnectionStrings");
                optionsBuilder.UseMySql(section["Url"], new MySqlServerVersion(new Version(10, 1, 40)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProductBuyLog>(entity =>
            {
                entity.ToTable("customer_product_buy_log");

                entity.HasComment("客户产品购买记录表");

                entity.HasIndex(e => e.QqtId, "buy_log_qqt_id");

                entity.HasIndex(e => e.CreateTime, "index_createTime");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(15)")
                    .HasColumnName("id");

                entity.Property(e => e.AccountNo)
                    .HasColumnType("varchar(11)")
                    .HasColumnName("account_no")
                    .HasComment("购买时的交易账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasComment("支付金额");

                entity.Property(e => e.Ccy)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("ccy")
                    .HasComment("支付币种")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("数据创建时间");

                entity.Property(e => e.EffectTime)
                    .HasColumnType("datetime")
                    .HasColumnName("effect_time")
                    .HasComment("生效时间");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("datetime")
                    .HasColumnName("expire_time")
                    .HasComment("失效时间");

                entity.Property(e => e.OrderNo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("order_no")
                    .HasComment("订单编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentNo)
                    .HasColumnType("varchar(48)")
                    .HasColumnName("payment_no")
                    .HasComment("支付流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id")
                    .HasComment("产品id");

                entity.Property(e => e.ProductType)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("product_type")
                    .HasComment("产品类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PurchaseChannel)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("purchase_channel")
                    .HasComment("购买渠道:IOS,Android")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QqtId)
                    .HasColumnType("varchar(35)")
                    .HasColumnName("qqt_id")
                    .HasComment("全球通用户id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RestoreStatus)
                    .HasColumnType("int(2)")
                    .HasColumnName("restore_status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("积分返还状态： 0未返还，1已返还,2只参与过计算未返还");

                entity.Property(e => e.RestoreTime)
                    .HasColumnType("datetime")
                    .HasColumnName("restore_time")
                    .HasComment("积分返回时间");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasComment("支付结果:0-支付中,1-支付失败，2-支付成功");

                entity.Property(e => e.SyncStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("sync_status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("同步状态,0未同步，1已转换成excel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
