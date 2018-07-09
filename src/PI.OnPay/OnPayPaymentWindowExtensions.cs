using PI.OnPay.Models;
using System;

namespace PI.OnPay
{
    public static class OnPayPaymentWindowExtensions
    {
        public static PaymentWindow SetCurrency(this PaymentWindow pw, string currency)
        {
            pw.Currency = currency;
            return pw;
        }

        public static PaymentWindow SetAmount(this PaymentWindow pw, decimal amount)
        {
            pw.Amount = Convert.ToInt32(amount * 100);
            return pw;
        }

        public static PaymentWindow SetCallbackUrl(this PaymentWindow pw, string callbackUrl)
        {
            pw.CallbackUrl = callbackUrl;
            return pw;
        }

        public static PaymentWindow SetAcceptUrl(this PaymentWindow pw, string acceptUrl)
        {
            pw.AcceptUrl = acceptUrl;
            return pw;
        }

        public static PaymentWindow SetDeclineUrl(this PaymentWindow pw, string declineUrl)
        {
            pw.DeclineUrl = declineUrl;
            return pw;
        }

        public static PaymentWindow SetReference(this PaymentWindow pw, string reference)
        {
            pw.Reference = reference;
            return pw;
        }

        public static PaymentWindow SetDesign(this PaymentWindow pw, string design)
        {
            pw.Design = design;
            return pw;
        }

        public static PaymentWindow SetMethod(this PaymentWindow pw, string method)
        {
            pw.Method = method;
            return pw;
        }

        public static PaymentWindow SetType(this PaymentWindow pw, string type)
        {
            pw.Type = type;
            return pw;
        }

        public static PaymentWindow SetLanguage(this PaymentWindow pw, string language)
        {
            pw.Language = language;
            return pw;
        }

        public static PaymentWindow EnableTestMode(this PaymentWindow pw)
        {
            pw.TestMode = true;
            return pw;
        }

        public static PaymentWindow Enable3DSecure(this PaymentWindow pw)
        {
            pw.SecureEnabled = true;
            return pw;
        }

        public static PaymentWindow AddCustomParameter(this PaymentWindow pw, string key, string value)
        {
            if (pw.CustomKeys == null)
                pw.CustomKeys = new System.Collections.Generic.Dictionary<string, string>();

            pw.CustomKeys.Add(key, value);

            return pw;
        }
    }
}
