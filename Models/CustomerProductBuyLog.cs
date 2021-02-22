using System;
using System.Collections.Generic;

#nullable disable

namespace NetCoreMixProject.Models
{
    public partial class CustomerProductBuyLog
    {
        public long Id { get; set; }
        public string QqtId { get; set; }
        public string OrderNo { get; set; }
        public string PaymentNo { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Ccy { get; set; }
        public double? Amount { get; set; }
        public int? Status { get; set; }
        public string PurchaseChannel { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EffectTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public string AccountNo { get; set; }
        public int? SyncStatus { get; set; }
        public int? RestoreStatus { get; set; }
        public DateTime? RestoreTime { get; set; }
    }
}
