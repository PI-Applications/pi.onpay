using PI.OnPay.Models;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PI.OnPay
{
    public class TransactionResources
    {
        private readonly IRestClient _resourceClient;

        public TransactionResources(IRestClient resourceClient)
        {
            _resourceClient = resourceClient;
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(Guid transactionId)
        {
            return await GetTransaction(transactionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(int transactionId)
        {
            return await GetTransaction(transactionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> GetTransaction(string resourceIdentifier)
        {
            var request = new RestRequest($"/v1/transaction/{resourceIdentifier}");
            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedTransaction>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(Guid transactionId, decimal? amount = null)
        {
            return await CaptureTransaction(transactionId.ToString(), amount);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(int transactionId, decimal? amount = null)
        {
            return await CaptureTransaction(transactionId.ToString(), amount);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CaptureTransaction(string resourceIdentifier, decimal? amount = null)
        {
            var requestBody = new RequestWithData<CaptureTransaction>
            {
                data = new CaptureTransaction
                {
                    amount = Convert.ToInt32(amount * 100)
                }
            };

            if (!amount.HasValue)
                requestBody = null;

            var request = new RestRequest($"/v1/transaction/{resourceIdentifier}/capture", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(requestBody);

            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedTransaction>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(Guid transactionId, decimal? amount = null)
        {
            return await RefundTransaction(transactionId.ToString(), amount);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(int transactionId, decimal? amount = null)
        {
            return await RefundTransaction(transactionId.ToString(), amount);
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> RefundTransaction(string resourceIdentifier, decimal? amount = null)
        {
            var requestBody = new RequestWithData<RefundTransaction>
            {
                data = new RefundTransaction
                {
                    amount = Convert.ToInt32(amount * 100)
                }
            };

            if (!amount.HasValue)
                requestBody = null;

            var request = new RestRequest($"/v1/transaction/{resourceIdentifier}/refund", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(requestBody);

            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedTransaction>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(Guid transactionId)
        {
            return await CancelTransaction(transactionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(int transactionId)
        {
            return await CancelTransaction(transactionId.ToString());
        }

        public async Task<ResponseWithLinks<DetailedTransaction>> CancelTransaction(string resourceIdentifier)
        {
            var request = new RestRequest($"/v1/transaction/{resourceIdentifier}/cancel", Method.POST);
            var response = await _resourceClient.ExecuteTaskAsync<ResponseWithLinks<DetailedTransaction>>(request);

            if (response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }
    }
}
