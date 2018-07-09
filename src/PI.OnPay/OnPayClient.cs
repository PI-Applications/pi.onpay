using PI.OnPay.Interfaces;
using RestSharp;

namespace PI.OnPay
{
    public class OnPayClient : IOnPayClient
    {
        private readonly string _accessToken;
        private readonly IRestClient _resourceClient;

        public OnPayClient(string accessToken)
        {
            _accessToken = accessToken;

            _resourceClient = new RestClient("https://api.onpay.io/");
            _resourceClient.AddDefaultHeader("Authorization", "Bearer " + _accessToken);
        }

        public OnPayClient(string accessToken, IRestClient resourceClient)
        {
            _accessToken = accessToken;
            _resourceClient = resourceClient;
        }

        public ITransactionResources Transactions
        {
            get
            {
                return new TransactionResources(_resourceClient);
            }
        }

        public ISubscriptionResources Subscriptions
        {
            get
            {
                return new SubscriptionResources(_resourceClient);
            }
        }
    }
}
