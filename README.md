# OnPay.io .NET SDK

![Visual Studio Team services](https://img.shields.io/vso/build/pi-applications-dk/8c43066a-ced2-41f9-822b-b5a7154a9b31/76.svg)
[![NuGet](https://img.shields.io/nuget/v/PI.OnPay.svg)](https://www.nuget.org/packages/PI.OnPay/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/PI.OnPay.svg)](https://www.nuget.org/packages/PI.OnPay/)

A .NET SDK for developing against the OnPay.io platform.

## Requirements
.NET Framework 4.5.2 or .NET Standard 2.0

## Authentication

Authentication is done through OAUTH2.

It is not necessary to register clients prior to usage, the client id should be set to the domain name of the integration owner.

```csharp
var onPayAuth = new OnPayAuthentication("clientId");

// Step 1: Redirect user to the returned url
var authUrl = await onPayAuth.GetAuthorizeUrl("gatewayId", "https://localhost:1337/onpay-auth");

// Step 2: Read 'code' from query to get a access token
var authorizationCode = Request.QueryString["code"];
var accessTokenResponse = await onPayAuth.GetAccessTokenByAuthorizationCode(authorizationCode, "redirectUri");

// Use refresh token to generate new valid access token
var refreshTokenResponse = await onPayAuth.GetAccessTokenByRefreshToken(accessTokenResponse.refresh_token);
```

## API

To use the API you need a access token. See example above.
```csharp
var onPayApi = new OnPayApi("accessToken");
```

### Resource identifier

All single item methods supports identifier as `Guid`, `int` and `string`.
```csharp
// Guid example
var transactionGuid = Guid.Parse("e3db3678-836f-11e8-846a-0dd9ab50386c");
await onPayApi.Transactions.GetTransaction(transactionGuid);

// Int example
await onPayApi.Transactions.GetTransaction(1234);

// String examples
await onPayApi.Transactions.GetTransaction("1234");
await onPayApi.Transactions.GetTransaction("e3db3678-836f-11e8-846a-0dd9ab50386c");
```


### Transactions
```csharp
// Get transaction details
await onPayApi.Transactions.GetTransaction(1234);

// Capture transaction - full amount or partial
await onPayApi.Transactions.CaptureTransaction(1234);
await onPayApi.Transactions.CaptureTransaction(1234, 100);

// Refund transaction - full amount or partial
await onPayApi.Transactions.RefundTransaction(1234);
await onPayApi.Transactions.RefundTransaction(1234, 100);

// Cancel transaction
await onPayApi.Transactions.CancelTransaction(1234);
```

### Subscriptions
```csharp
// Get subscription details
await onPayApi.Subscriptions.GetSubscription(1234);

// Cancel subscription
await onPayApi.Subscriptions.CancelSubscription(1234);

// Authorize new transaction by subscription
await onPayApi.Subscriptions.AuthorizeSubscription(1234, 100, "OrderId");
```

## Payment window

Creating parameters for the payment window is done through a fluent flow.

### Getting started
```csharp
// Not all parameters is required, it's just shown as an example
var windowParameters = new OnPayPaymentWindow("gatewayId", "windowSecret")
                                .SetCurrency("DKK")
                                .SetAmount(123)
                                .SetReference("unique-ref-9999")
                                .SetCallbackUrl("https://localhost:1337/payment/callback")
                                .SetAcceptUrl("https://localhost:1337/payment/accept")
                                .SetDeclineUrl("https://localhost:1337/payment/decline")
                                .SetDesign("DesignName")
                                .SetMethod(OnPayMethod.Payment)
                                .SetType(OnPayType.Card)
                                .SetLanguage(OnPayLanguage.DA)
                                .EnableTestMode() 
                                .Enable3DSecure()
                                .AddCustomParameter("custom-param","custom-value")
                                .GenerateParamters();
```

### Use the generated parameters
```html
<!-- MVC example -->
<form action="https://onpay.io/window/v3/" method="post" id="onPayForm">
	@foreach(KeyValuePair<string, string> windowParam in Model.Parameters)
	{
		<input type="hidden" name="@windowParam.Key" value="@windowParam.Value" />
	}

	 <input type="submit" value="Go to payment window">
</form>
```