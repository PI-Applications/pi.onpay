using System.Collections.Generic;

namespace PI.OnPay.Models
{
    public class DetailedSubscription
    {
        public bool _3dsecure { get; set; }
        public string acquirer { get; set; }
        public string card_bin { get; set; }
        public string card_type { get; set; }
        public string created { get; set; }
        public int currency_code { get; set; }
        public int expiry_month { get; set; }
        public int expiry_year { get; set; }
        public string ip { get; set; }
        public string order_id { get; set; }
        public string status { get; set; }
        public int subscription_number { get; set; }
        public string uuid { get; set; }
        public string wallet { get; set; }
        public List<SubscriptionHistory> history { get; set; }
        public List<SimpleTransaction> transactions { get; set; }
    }
}
