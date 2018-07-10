namespace PI.OnPay.Interfaces
{
    public interface IOnPayApi
    {
        ISubscriptionResources Subscriptions { get; }
        ITransactionResources Transactions { get; }
    }
}