using System;
using System.Collections.Generic;

#nullable disable

namespace NetCoreMixProject.Models
{
    public partial class r_retail_customer_product_buy_log
    {
        public int id { get; set; }
        public string qqt_id { get; set; }
        public string order_no { get; set; }
        public string payment_no { get; set; }
        public int product_id { get; set; }
        public string product_type { get; set; }
        public string ccy { get; set; }
        public decimal? amount { get; set; }
        public int? status { get; set; }
        public string purchase_channel { get; set; }
        public DateTime create_time { get; set; }
        public DateTime? effect_time { get; set; }
        public DateTime? expire_time { get; set; }
        public string account_no { get; set; }
        public int? sync_status { get; set; }
        public int? restore_status { get; set; }
        public DateTime? restore_time { get; set; }
    }
}
