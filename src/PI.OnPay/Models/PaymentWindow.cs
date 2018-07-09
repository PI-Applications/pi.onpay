using System.Collections.Generic;

namespace PI.OnPay.Models
{
    public class PaymentWindow
    {
        public string GatewayId { get; set; }
        public string Currency { get; set; }
        public int Amount { get; set; }
        public string Reference { get; set; }
        public string AcceptUrl { get; set; }
        public string DeclineUrl { get; set; }
        public string CallbackUrl { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public bool SecureEnabled { get; set; }
        public string Design { get; set; }
        public string Language { get; set; }
        public bool TestMode { get; set; }
        public string HMAC { get; set; }
        public Dictionary<string,string> CustomKeys { get; set; }
    }
}
