using System;
using System.Collections.Generic;

#nullable disable

namespace NetCoreMixProject.Models
{
    public partial class sv_collateral_result
    {
        public decimal? dc_business_date { get; set; }
        public DateTime? dc_collect_date { get; set; }
        public decimal? dc_program_id { get; set; }
        public decimal? dc_server_id { get; set; }
        public decimal id { get; set; }
        public DateTime? pub_date { get; set; }
        public DateTime? changed_time { get; set; }
        public decimal secucode { get; set; }
        public string secuname { get; set; }
        public string tradingcode { get; set; }
        public string exchangecode { get; set; }
        public string exchangename { get; set; }
        public decimal? type { get; set; }
        public string secutype { get; set; }
        public string listing_date { get; set; }
        public string de_listing_date { get; set; }
        public decimal? base_convert_rate { get; set; }
        public string base_remark { get; set; }
        public decimal? upperlimit_convert_rate { get; set; }
        public string upperlimit_remark { get; set; }
        public decimal? exchange_convert_rate { get; set; }
        public string exchange_remark { get; set; }
        public decimal? opt_convert_rate { get; set; }
        public string opt_reason { get; set; }
        public decimal? final_convert_rate { get; set; }
        public string rate_remark { get; set; }
        public decimal? flag { get; set; }
        public string flag_remark { get; set; }
        public decimal? opt_flag { get; set; }
        public string opt_user_id { get; set; }
        public string opt_user_name { get; set; }
        public decimal? exchange_flag { get; set; }
        public string exchange_flag_remark { get; set; }
        public decimal? final_flag { get; set; }
        public string final_flag_remark { get; set; }
        public decimal? financing_marks { get; set; }
        public decimal? opt_financing_marks { get; set; }
        public decimal? final_financing_marks { get; set; }
        public decimal? securities_marks { get; set; }
        public decimal? opt_securities_marks { get; set; }
        public decimal? final_securities_marks { get; set; }
        public decimal? pe_eps { get; set; }
        public decimal? pe_eps_weight { get; set; }
        public decimal? pe_market { get; set; }
        public decimal? pb { get; set; }
        public decimal? stock_score { get; set; }
        public decimal? margin_score { get; set; }
        public decimal? is_new { get; set; }
        public string com_rating { get; set; }
        public string bnd_rating { get; set; }
        public string ftypecodei { get; set; }
        public string ftypecodeii { get; set; }
        public string risk_level { get; set; }
        public decimal? rule_price_change { get; set; }
        public decimal? rule_pb { get; set; }
        public decimal? rule_new { get; set; }
        public decimal? rule_s { get; set; }
        public decimal? rule_audit { get; set; }
        public decimal? rule_equity { get; set; }
        public decimal? rule_stop { get; set; }
        public decimal? rule_pe { get; set; }
        public decimal? rule_pe_ttm { get; set; }
        public decimal? pe_ttm { get; set; }
        public decimal? closing_price { get; set; }
        public decimal? closing_price_60 { get; set; }
        public decimal? closing_price_lastweek { get; set; }
        public decimal? total_share { get; set; }
        public decimal? net_profitcoms { get; set; }
        public decimal? stop_days { get; set; }
        public string pause_reason { get; set; }
        public string report_date { get; set; }
        public string report_date_year { get; set; }
        public decimal? total_equity { get; set; }
        public decimal? equity_holder { get; set; }
        public string audit_opinion { get; set; }
        public string index_code { get; set; }
        public decimal? is_opt { get; set; }
        public decimal? is_after_pe { get; set; }
        public decimal? opt_new_collateral_flag { get; set; }
    }
}
