using PI.OnPay.Interfaces;
using RestSharp;

namespace PI.OnPay
{
    public class OnPayApi : IOnPayApi
    {
        private readonly string _accessToken;
        private readonly IRestClient _resourceClient;

        public OnPayApi(string accessToken)
        {
            _accessToken = accessToken;

            _resourceClient = new RestClient("https://api.onpay.io/");
            _resourceClient.AddDefaultHeader("Authorization", "Bearer " + _accessToken);
        }

        public OnPayApi(string accessToken, IRestClient resourceClient)
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
