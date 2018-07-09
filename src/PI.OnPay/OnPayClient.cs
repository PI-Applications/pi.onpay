using PI.OnPay.Models;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PI.OnPay
{
    public class OnPayClient
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

        public TransactionResources Transactions
        {
            get
            {
                return new TransactionResources(_resourceClient);
            }
        }

        public SubscriptionResources Subscriptions
        {
            get
            {
                return new SubscriptionResources(_resourceClient);
            }
        }
    }
}
