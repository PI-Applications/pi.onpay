namespace PI.OnPay.Interfaces
{
    public interface IOnPayClient
    {
        ISubscriptionResources Subscriptions { get; }
        ITransactionResources Transactions { get; }
    }
}