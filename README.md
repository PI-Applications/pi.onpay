# OnPay.io .NET SDK

A .NET SDK for developing against the OnPay.io platform.

## Requirements
.NET Framework 4.5.2 or .NET Standard 2.0

## Getting started
```csharp
var onPayClient = new OnPayClient("accessToken");
```

## Transactions
```csharp
// Get transaction details
await onPayClient.Transactions.GetTransaction(1234);

// Capture transaction - full amount or some
await onPayClient.Transactions.CaptureTransaction(1234);
await onPayClient.Transactions.CaptureTransaction(1234, 100);

// Refund transaction - full amount or some
await onPayClient.Transactions.RefundTransaction(1234);
await onPayClient.Transactions.RefundTransaction(1234, 100);

// Cancel transaction
await onPayClient.Transactions.CancelTransaction(1234);
```

## Subscriptions
```csharp
// Get subscription details
await onPayClient.Subscriptions.GetSubscription(1234);

// Cancel subscription
await onPayClient.Subscriptions.CancelSubscription(1234);

// Authorize new transaction by subscription
await onPayClient.Subscriptions.AuthorizeSubscription(1234, 100, "OrderId");
```

## Payment window
Not supported yet
