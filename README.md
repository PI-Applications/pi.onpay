# OnPay.io .NET SDK

A .NET SDK for developing against the OnPay.io platform.

## Requirements
.NET Framework 4.5.2 or .NET Standard 2.0

## API usage

To use the API an access token is needed. In future this package will contain helpers for this.

### Getting started
```csharp
var onPayApi = new OnPayApi("accessToken");
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