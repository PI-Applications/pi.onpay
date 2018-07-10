using System.Threading.Tasks;
using PI.OnPay.Models;

namespace PI.OnPay.Interfaces
{
    public interface IOnPayAuthentication
    {
        Task<string> GetAuthorizeUrl(string gatewayId, string redirectUri);
        Task<AccessTokenResponse> GetAccessTokenByAuthorizationCode(string authorizationCode, string redirectUri);
        Task<AccessTokenResponse> GetAccessTokenByRefreshToken(string refreshToken);
    }
}