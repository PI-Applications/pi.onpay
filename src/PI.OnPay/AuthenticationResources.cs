using PI.OnPay.Interfaces;
using PI.OnPay.Models;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PI.OnPay
{
    public class AuthenticationResources : IAuthenticationResources
    {
        private readonly IRestClient _resourceClient;

        public AuthenticationResources(IRestClient resourceClient)
        {
            _resourceClient = resourceClient;
        }

        public Task<string> GetAuthorizeUrl(string gatewayId, string clientId, string redirectUri)
        {
            var link = $"https://manage.onpay.io/{gatewayId}/oauth2/authorize?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope=full";

            return Task.FromResult(link);
        }

        public async Task<AccessTokenResponse> GetAccessTokenByAuthorizationCode(string clientId, string authorizationCode, string redirectUri)
        {
            var request = new RestRequest("/oauth2/access_token", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=authorization_code&code={authorizationCode}&client_id={clientId}&redirect_uri={redirectUri}", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = await _resourceClient.ExecuteTaskAsync<AccessTokenResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Content);

            return response.Data;
        }

        public async Task<AccessTokenResponse> GetAccessTokenByRefreshToken(string clientId, string refreshToken)
        {
            var request = new RestRequest("/oauth2/access_token", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=refresh_token&refresh_token={refreshToken}&client_id={clientId}", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = await _resourceClient.ExecuteTaskAsync<AccessTokenResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Content);

            return response.Data;
        }
    }
}
