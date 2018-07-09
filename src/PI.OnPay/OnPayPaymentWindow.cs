using PI.OnPay.Models;

namespace PI.OnPay
{
    public class OnPayPaymentWindow
    {
        private readonly string _gatewayId;
        private readonly string _windowSecret;

        public OnPayPaymentWindow(string gatewayId, string windowSecret)
        {
            _gatewayId = gatewayId;
            _windowSecret = windowSecret;
        }

        public PaymentWindow CreateWindow()
        {
            return new PaymentWindow
            {
                GatewayId = _gatewayId
            };
        }

        public string GenerateWindowHtml(PaymentWindow window)
        {
            // Generate hash

            // Generate html
            
            // return it

            return null;
        }
    }
}
