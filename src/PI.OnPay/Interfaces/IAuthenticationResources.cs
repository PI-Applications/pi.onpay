using System.Threading.Tasks;
using PI.OnPay.Models;

namespace PI.OnPay.Interfaces
{
    public interface IAuthenticationResources
    {
        Task<AccessTokenResponse> GetAccessTokenByAuthorizationCode(string clientId, string authorizationCode, string redirectUri);
        Task<AccessTokenResponse> GetAccessTokenByRefreshToken(string clientId, string refreshToken);
    }
}