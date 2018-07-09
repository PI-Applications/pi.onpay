namespace PI.OnPay.Interfaces
{
    public interface IOnPayApi
    {
        IAuthenticationResources Authentication { get; }
        ISubscriptionResources Subscriptions { get; }
        ITransactionResources Transactions { get; }
    }
}