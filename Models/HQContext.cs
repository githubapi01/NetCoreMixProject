using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace NetCoreMixProject.Models
{
    public partial class HQContext : DbContext
    {
        public HQContext()
        {
        }

        public HQContext(DbContextOptions<HQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<r_retail_customer_product_buy_log> r_retail_customer_product_buy_logs { get; set; }
        public virtual DbSet<sv_collateral_result> sv_collateral_results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationSection section = ConfigHelper.Get("HQConnectionStrings");
                optionsBuilder.UseSqlServer(section["Url"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_Stroke_CI_AI_KS_WS");

            modelBuilder.Entity<r_retail_customer_product_buy_log>(entity =>
            {
                entity.ToTable("r_retail_customer_product_buy_log");

                entity.HasComment("客户产品购买记录表");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.account_no)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("购买时的交易账号");

                entity.Property(e => e.amount)
                    .HasColumnType("numeric(12, 2)")
                    .HasComment("支付金额");

                entity.Property(e => e.ccy)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("支付币种");

                entity.Property(e => e.create_time)
                    .HasColumnType("datetime")
                    .HasComment("数据创建时间");

                entity.Property(e => e.effect_time)
                    .HasColumnType("datetime")
                    .HasComment("生效时间");

                entity.Property(e => e.expire_time)
                    .HasColumnType("datetime")
                    .HasComment("失效时间");

                entity.Property(e => e.order_no)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("订单编号");

                entity.Property(e => e.payment_no)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasComment("支付流水号");

                entity.Property(e => e.product_id).HasComment("产品id");

                entity.Property(e => e.product_type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("产品类型");

                entity.Property(e => e.purchase_channel)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("购买渠道:IOS,Android");

                entity.Property(e => e.qqt_id)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasComment("全球通用户id");

                entity.Property(e => e.restore_status)
                    .HasDefaultValueSql("('0')")
                    .HasComment("积分返还状态： 0未返还，1已返还,2只参与过计算未返还");

                entity.Property(e => e.restore_time)
                    .HasColumnType("datetime")
                    .HasComment("积分返回时间");

                entity.Property(e => e.status).HasComment("支付结果:0-支付中,1-支付失败，2-支付成功");

                entity.Property(e => e.sync_status)
                    .HasDefaultValueSql("('0')")
                    .HasComment("同步状态,0未同步，1已转换成excel");
            });

            modelBuilder.Entity<sv_collateral_result>(entity =>
            {
                entity.ToTable("sv_collateral_result");

                entity.Property(e => e.id).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.audit_opinion).HasMaxLength(255);

                entity.Property(e => e.base_convert_rate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.base_remark).HasMaxLength(200);

                entity.Property(e => e.bnd_rating).HasMaxLength(20);

                entity.Property(e => e.changed_time).HasColumnType("datetime");

                entity.Property(e => e.closing_price).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.closing_price_60).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.closing_price_lastweek).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.com_rating).HasMaxLength(20);

                entity.Property(e => e.dc_business_date).HasColumnType("numeric(8, 0)");

                entity.Property(e => e.dc_collect_date).HasColumnType("datetime");

                entity.Property(e => e.dc_program_id).HasColumnType("numeric(32, 0)");

                entity.Property(e => e.dc_server_id).HasColumnType("numeric(32, 0)");

                entity.Property(e => e.de_listing_date).HasMaxLength(20);

                entity.Property(e => e.equity_holder).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.exchange_convert_rate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.exchange_flag).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.exchange_flag_remark).HasMaxLength(255);

                entity.Property(e => e.exchange_remark).HasMaxLength(200);

                entity.Property(e => e.exchangecode).HasMaxLength(32);

                entity.Property(e => e.exchangename).HasMaxLength(32);

                entity.Property(e => e.final_convert_rate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.final_financing_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.final_flag).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.final_flag_remark).HasMaxLength(255);

                entity.Property(e => e.final_securities_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.financing_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.flag).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.flag_remark).HasMaxLength(255);

                entity.Property(e => e.ftypecodei).HasMaxLength(20);

                entity.Property(e => e.ftypecodeii).HasMaxLength(20);

                entity.Property(e => e.index_code).HasMaxLength(100);

                entity.Property(e => e.is_after_pe).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.is_new).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.is_opt).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.listing_date).HasMaxLength(20);

                entity.Property(e => e.margin_score).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.net_profitcoms).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.opt_convert_rate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.opt_financing_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.opt_flag).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.opt_new_collateral_flag).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.opt_reason).HasMaxLength(1000);

                entity.Property(e => e.opt_securities_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.opt_user_id).HasMaxLength(20);

                entity.Property(e => e.opt_user_name).HasMaxLength(20);

                entity.Property(e => e.pause_reason).HasMaxLength(100);

                entity.Property(e => e.pb).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.pe_eps).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.pe_eps_weight).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.pe_market).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.pe_ttm).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.pub_date).HasColumnType("datetime");

                entity.Property(e => e.rate_remark).HasMaxLength(200);

                entity.Property(e => e.report_date).HasMaxLength(20);

                entity.Property(e => e.report_date_year).HasMaxLength(20);

                entity.Property(e => e.risk_level).HasMaxLength(20);

                entity.Property(e => e.rule_audit).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_equity).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_new).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_pb).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_pe).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_pe_ttm).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_price_change).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_s).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.rule_stop).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.secucode).HasColumnType("numeric(19, 0)");

                entity.Property(e => e.secuname).HasMaxLength(50);

                entity.Property(e => e.securities_marks).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.secutype).HasMaxLength(50);

                entity.Property(e => e.stock_score).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.stop_days).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.total_equity).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.total_share).HasColumnType("decimal(20, 4)");

                entity.Property(e => e.tradingcode).HasMaxLength(50);

                entity.Property(e => e.type).HasColumnType("numeric(5, 0)");

                entity.Property(e => e.upperlimit_convert_rate).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.upperlimit_remark).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
