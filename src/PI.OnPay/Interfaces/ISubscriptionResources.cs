using System;
using System.Threading.Tasks;
using PI.OnPay.Models;

namespace PI.OnPay.Interfaces
{
    public interface ISubscriptionResources
    {
        Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(Guid subscriptionId, decimal amount, string orderId);
        Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(int subscriptionId, decimal amount, string orderId);
        Task<ResponseWithLinks<DetailedTransaction>> AuthorizeSubscription(string resourceIdentifier, decimal amount, string orderId);
        Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(Guid subscriptionId);
        Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(int subscriptionId);
        Task<ResponseWithLinks<DetailedSubscription>> CancelSubscription(string resourceIdentifier);
        Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(Guid subscriptionId);
        Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(int subscriptionId);
        Task<ResponseWithLinks<DetailedSubscription>> GetSubscription(string resourceIdentifier);
    }
}