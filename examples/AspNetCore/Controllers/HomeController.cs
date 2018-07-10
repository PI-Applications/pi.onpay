using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;
using PI.OnPay;
using PI.OnPay.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnPayConfig _onPayConfig;

        public HomeController(IOptions<OnPayConfig> onPayConfig)
        {
            _onPayConfig = onPayConfig.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentWindow()
        {            
            var windowParams = new OnPayPaymentWindow(_onPayConfig.GatewayId, _onPayConfig.WindowSecret)
                .SetCurrency("DKK")
                .SetAmount(123)
                .SetReference("unique-ref-9999")
                .SetCallbackUrl("http://localhost:61437/Home/PaymentWindow")
                .SetAcceptUrl("http://localhost:61437/Home/PaymentWindow")
                .SetDeclineUrl("http://localhost:61437/Home/PaymentWindow")
                .SetDesign("next")
                .SetMethod(OnPayMethod.Card)
                .SetType(OnPayType.Payment)
                .SetLanguage(OnPayLanguage.DA)
                .EnableTestMode()
                //.Enable3DSecure()
                .AddCustomParameter("custom-param", "custom-value")
                .GenerateParamters();

            var model = new PaymentWindowModel
            {
                Parameters = windowParams
            };

            return View(model);
        }

        public async Task<IActionResult> Api()
        {
            var onPayApi = new OnPayApi("access-token");

            var transactionDetails = await onPayApi.Transactions.GetTransaction("db9c6f40-aca0-419e-90de-53552bf3518a");

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
