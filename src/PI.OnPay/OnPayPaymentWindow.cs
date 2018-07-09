using System.Collections.Generic;

namespace PI.OnPay
{
    public class OnPayPaymentWindow
    {
        public OnPayPaymentWindow(string gatewayId, string windowSecret)
        {
            GatewayId = gatewayId;
            WindowSecret = windowSecret;            
        }

        public string GatewayId { get; internal set; }
        public string WindowSecret { internal get; set; }
        public string HMAC { internal get; set; }
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
        public Dictionary<string, string> CustomKeys { get; set; }
    }
}
