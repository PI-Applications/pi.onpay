# OnPay.io .NET SDK

![Visual Studio Team services](https://img.shields.io/vso/build/pi-applications-dk/8c43066a-ced2-41f9-822b-b5a7154a9b31/76.svg)
[![NuGet](https://img.shields.io/nuget/v/PI.OnPay.svg)](https://www.nuget.org/packages/PI.OnPay/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/PI.OnPay.svg)](https://www.nuget.org/packages/PI.OnPay/)

A .NET SDK for developing against the OnPay.io platform.

## Requirements
.NET Framework 4.5.2 or .NET Standard 2.0

## API usage

### Getting started with an access token
```csharp
var onPayApi = new OnPayApi("accessToken");
```

### Getting started without an access token
```csharp
var onPayApi = new OnPayApi();

// Get authorize url, and redirect to url
// Read 'code' from query on callback - see section 'Authentication'
// Remember to create an new instance of OnPayApi with access token as constructor parameter
var authorizeUrl = await onPayApi.Authentication.GetAuthorizeUrl("1234567890", "clientId", "https://localhost:1337/onpay-auth");
```

### Authentication
```csharp
// Get access token by authorization code
var authorizationCode = Request.QueryString["code"];
var response1 = await onPayApi.Authentication.GetAccessTokenByAuthorizationCode("clientId", "authorizationCode", "redirectUri");
var accessToken1 = response1.access_token;

// Get access token by refresh token
var response2 = await onPayApi.Authentication.GetAccessTokenByRefreshToken("clientId", response1.refresh_token);
var accessToken2 = response2.access_token; 
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

## Payment window usage

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