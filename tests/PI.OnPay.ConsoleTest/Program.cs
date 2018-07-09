using System;

namespace PI.OnPay.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var onPayClient = new OnPayClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjQ2ODgwNDNlNTY5M2ZlMDRhYWZkNWM1NDRjZTYxZjM3ZDE1MjFmNTdiM2JiYzg2ZDJmOGI1Y2VmOTkxYjk3NGM0OTgzNTU5YTQ4ZTAzZThkIn0.eyJhdWQiOiJQd3JUZXN0IiwianRpIjoiNDY4ODA0M2U1NjkzZmUwNGFhZmQ1YzU0NGNlNjFmMzdkMTUyMWY1N2IzYmJjODZkMmY4YjVjZWY5OTFiOTc0YzQ5ODM1NTlhNDhlMDNlOGQiLCJpYXQiOjE1MzExMzIwODMsIm5iZiI6MTUzMTEzMjA4MywiZXhwIjoxNTMxMjE4NDgzLCJzdWIiOiIyMDEzMDQxODE2MTM0MyIsInNjb3BlcyI6WyJmdWxsIl19.YYFMYDvyuInwAZUKzdE-CgqGKH5tf0RpCR_1j-B9Cg_d0ReZIO0UzAZv-3Mzd2AVkK_U7E7-77DuWFh3xwI9LCO_0_jMXYdAXgQffr7S3hN7VwGfv_Ty9mLASCU751UPQvKNDrKYRQiE53sHnSJYjZf2OYEUiwBPNLTj6VLtOZh02Kx6emEsUtXVw3OYPWaMH1nRv_bcaoffTomcG1lAqtRxRnQLo_V-w0TNZEMcoLZ3WvJaSPYDWw3HvvHlfDp77_bXNoCp83KLQIwyNCtOZUr5Gm6azKQMdnwq8HnxdONE04GgHK3mFr0NFPAh6Omx-U5Aidr7oH-uIU47m5lVUA");

            //onPayClient.Subscriptions.AuthorizeSubscription(155579, 100, "HHHHHHasdasd").Wait();

            onPayClient.Transactions.RefundTransaction(155599, 25).Wait();
        }
    }
}
