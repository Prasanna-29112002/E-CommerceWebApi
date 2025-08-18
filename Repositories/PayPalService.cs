using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PayPalService : IPayPalService
{
    private readonly string clientId = "AYMYsV8i2-HVGE3a9empoY36Qp56NoM9i-2OEeWGKZXx824Xu0r7orAhYoVpp0yd6Yrm9vZGTSPs703r";
    private readonly string clientSecret = "EMVO8U2PZOR9zD2raWF11SFlmGfDErlQc6q5U8VeDW2kqg14W_C-Tf9fmti96dhmi9K5zWl3poH-aTz0";


    public PayPalService(IConfiguration config)
    {
        clientId = config["PayPal:ClientId"];
        clientSecret = config["PayPal:ClientSecret"];
    }

    private PayPalEnvironment Environment => new SandboxEnvironment(clientId, clientSecret);
    private PayPalHttpClient Client => new PayPalHttpClient(Environment);

    public async Task<string> CreateTransactionAsync(decimal amount)
    {
        var request = new OrdersCreateRequest();
        request.Prefer("return=representation");
        request.RequestBody(new OrderRequest
        {
            CheckoutPaymentIntent = "CAPTURE",
            PurchaseUnits = new List<PurchaseUnitRequest>
            {
                new PurchaseUnitRequest
                {
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        CurrencyCode = "USD",
                        Value = amount.ToString("F2")
                    }
                }
            }
        });

        var response = await Client.Execute(request);
        var result = response.Result<Order>();
        return result.Id; // PayPal Transaction ID
    }
}