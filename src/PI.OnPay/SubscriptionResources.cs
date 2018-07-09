using PI.OnPay.Interfaces;
using PI.OnPay.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace PI.OnPay
{
    public class SubscriptionResources : ISubscriptionResources
    {
        private readonly IRestClient _resourceClient;

        public SubscriptionResources(IRestClient resourceClient)
        {
            _resourceClient = resourceClient;
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(Guid subscriptionId)
        {
            return await GetSubscription(subscriptionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(int subscriptionId)
        {
            return await GetSubscription(subscriptionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(string resourceIdentifier)
        {
            var request = new RestRequest($"/v1/subscription/{resourceIdentifier}");
            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedSubscription>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(Guid subscriptionId)
        {
            return await CancelSubscription(subscriptionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(int subscriptionId)
        {
            return await CancelSubscription(subscriptionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(string resourceIdentifier)
        {
            var request = new RestRequest($"/v1/subscription/{resourceIdentifier}/cancel", Method.POST);
            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedSubscription>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(Guid subscriptionId, decimal amount, string orderId)
        {
            return await AuthorizeSubscription(subscriptionId.ToString(), amount, orderId);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(int subscriptionId, decimal amount, string orderId)
        {
            return await AuthorizeSubscription(subscriptionId.ToString(), amount, orderId);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(string resourceIdentifier, decimal amount, string orderId)
        {
            var requestBody = new RequestWithData<SubscriptionAuthorize>
            {
                data = new SubscriptionAuthorize
                {
                    amount = Convert.ToInt32(amount * 100),
                    order_id = orderId
                }
            };

            var request = new RestRequest($"/v1/subscription/{resourceIdentifier}/authorize", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(requestBody);

            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedTransaction>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }
    }
}
