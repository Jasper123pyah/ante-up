using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ante_up.Common.DataModels;
using ante_up.Common.Interfaces.Data.Classes;
using ante_up.Logic.JWT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ante_up.Logic.Services
{
    public class BalanceLogic
    {
        private readonly IAccountData _accountData;
        private readonly IBalanceData _balanceData;

        public BalanceLogic() {}
        
        public BalanceLogic(IAccountData accountData, IBalanceData balanceData)
        {
            _accountData = accountData;
            _balanceData = balanceData;
        }

        public async Task<PaypalResponseRoot> GetOrderInfo(string id)
        {
            string url = $"https://api.sandbox.paypal.com/v2/checkout/orders/{id}";
            PaypalResponseRoot result;

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("GET"), url))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "application/json");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "en_US"); 

                    string base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("AeOHjVHKSkbiCamWuBn5wkGD6g1YS2YtXEepg6BJHlURMzUdcMvFbDc5h8Oe9oWagUz4a3BduY1IZsvr:ECzxLLY-OwI-rcLGnq11Hc3z0NIvgl5R1McADgFlgCzMMy0lRH2oyNJyucId-0eNtT_bWoIv0ZFnfJHQ"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}"); 

                    request.Content = new StringContent("grant_type=client_credentials");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded"); 

                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    
                    result = JsonConvert.DeserializeObject<PaypalResponseRoot>(responseBody);
                }
            }
            
            return result;
        }

        private int CalculateCredits(float value)
        {
            return Convert.ToInt32(value * 100);
        }
        
        public async Task UpdateAccountBalance(string token, string id)
        {
            string accountId = JWTLogic.GetId(token);
            Account account = _accountData.GetAccountById(accountId);
            // check if id doesnt exist yet
            PaypalResponseRoot paypalOrder = await GetOrderInfo(id);
            PaypalTransaction transaction = new PaypalTransaction()
            {
                PaypalId = paypalOrder.id,
                CaptureId = paypalOrder.purchase_units[0].payments.captures[0].id,
                PayerId = paypalOrder.payer.payer_id,
                Value = float.Parse(paypalOrder.purchase_units[0].amount.value),
                Ip = "",
                Actions = new List<PaypalAction>()
                {
                    new ()
                    {
                        PaypalId = paypalOrder.id,
                        Status = paypalOrder.status,
                        Time = paypalOrder.purchase_units[0].payments.captures[0].create_time
                    }
                },
                Credits = CalculateCredits(float.Parse(paypalOrder.purchase_units[0].amount.value)),
                CreateTime = paypalOrder.create_time,
                UpdateTime = paypalOrder.update_time
            };

            _balanceData.UpdateAccountBalance(account, transaction);
        }
    }
}