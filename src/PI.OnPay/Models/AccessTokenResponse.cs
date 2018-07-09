namespace PI.OnPay.Models
{
    public class AccessTokenResponse
    {
        public string error { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
    }
}
