namespace PI.OnPay.Models
{
    public class RequestWithData<T> where T : class
    {
        public T data { get; set; }
    }
}
