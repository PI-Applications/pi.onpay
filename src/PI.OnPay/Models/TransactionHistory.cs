namespace PI.OnPay.Models
{
    public class TransactionHistory
    {
        public string action { get; set; }
        public int amount { get; set; }
        public string author { get; set; }
        public string date_time { get; set; }
        public string ip { get; set; }
        public string result_code { get; set; }
        public string result_text { get; set; }
        public string uuid { get; set; }
    }
}
