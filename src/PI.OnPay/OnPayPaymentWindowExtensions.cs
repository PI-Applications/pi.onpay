using PI.OnPay.Models;
using System;
using System.Collections.Generic;

namespace PI.OnPay
{
    public static class OnPayPaymentWindowExtensions
    {
        public static OnPayPaymentWindow SetCurrency(this OnPayPaymentWindow pw, string currency)
        {
            pw.Currency = currency;
            return pw;
        }

        public static OnPayPaymentWindow SetAmount(this OnPayPaymentWindow pw, decimal amount)
        {
            pw.Amount = Convert.ToInt32(amount * 100);
            return pw;
        }

        public static OnPayPaymentWindow SetCallbackUrl(this OnPayPaymentWindow pw, string callbackUrl)
        {
            pw.CallbackUrl = callbackUrl;
            return pw;
        }

        public static OnPayPaymentWindow SetAcceptUrl(this OnPayPaymentWindow pw, string acceptUrl)
        {
            pw.AcceptUrl = acceptUrl;
            return pw;
        }

        public static OnPayPaymentWindow SetDeclineUrl(this OnPayPaymentWindow pw, string declineUrl)
        {
            pw.DeclineUrl = declineUrl;
            return pw;
        }

        public static OnPayPaymentWindow SetReference(this OnPayPaymentWindow pw, string reference)
        {
            pw.Reference = reference;
            return pw;
        }

        public static OnPayPaymentWindow SetDesign(this OnPayPaymentWindow pw, string design)
        {
            pw.Design = design;
            return pw;
        }

        public static OnPayPaymentWindow SetMethod(this OnPayPaymentWindow pw, string method)
        {
            pw.Method = method;
            return pw;
        }

        public static OnPayPaymentWindow SetType(this OnPayPaymentWindow pw, string type)
        {
            pw.Type = type;
            return pw;
        }

        public static OnPayPaymentWindow SetLanguage(this OnPayPaymentWindow pw, string language)
        {
            pw.Language = language;
            return pw;
        }

        public static OnPayPaymentWindow EnableTestMode(this OnPayPaymentWindow pw)
        {
            pw.TestMode = true;
            return pw;
        }

        public static OnPayPaymentWindow Enable3DSecure(this OnPayPaymentWindow pw)
        {
            pw.SecureEnabled = true;
            return pw;
        }

        public static OnPayPaymentWindow AddCustomParameter(this OnPayPaymentWindow pw, string key, string value)
        {
            if (pw.CustomKeys == null)
                pw.CustomKeys = new Dictionary<string, string>();

            pw.CustomKeys.Add(key, value);

            return pw;
        }

        public static string GenerateHtml(this OnPayPaymentWindow pw)
        {
            // Setup parameter list
            var windowParams = new Dictionary<string, string>
            {
                { "onpay_gatewayid", pw.GatewayId },
                { "onpay_currency", pw.Currency },
                { "onpay_amount", pw.Amount.ToString() },
                { "onpay_reference", pw.Reference },
                { "onpay_accepturl", pw.AcceptUrl },
                { "onpay_callbackurl", pw.CallbackUrl },
                { "onpay_declineurl", pw.DeclineUrl },
                { "onpay_type", pw.Type },
                { "onpay_method", pw.Method },
                { "onpay_language", pw.Language },
                { "onpay_design", pw.Design },
                { "onpay_testmode", pw.TestMode ? "1" : "0" },
                { "onpay_3dsecure", pw.SecureEnabled ? "forced" : "" }
            };

            // Generate HMAC
            var hmac = "todo-todo";
            windowParams.Add("onpay_hmac_sha1", hmac);
            
            // Generate html

            return "todo";
        }
    }
}
