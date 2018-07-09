using System.Collections.Generic;

namespace PI.OnPay.Models
{
    public class DetailedTransaction
    {
        public bool _3dsecure { get; set; }
        public string acquirer { get; set; }
        public int amount { get; set; }
        public string card_bin { get; set; }
        public string card_type { get; set; }
        public int charged { get; set; }
        public string created { get; set; }
        public int currency_code { get; set; }
        public int expiry_month { get; set; }
        public int expiry_year { get; set; }
        public string ip { get; set; }
        public string order_id { get; set; }
        public int refunded { get; set; }
        public string status { get; set; }
        public int subscription_number { get; set; }
        public string subscription_uuid { get; set; }
        public int transaction_number { get; set; }
        public string uuid { get; set; }
        public string wallet { get; set; }
        public List<TransactionHistory> History { get; set; }
    }
}
