using System;
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

        public BalanceLogic()
        {
        }
        
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

        public int GetFeelessAmount(double amount)
        {
            double ratio = 0.970873786407767;
            double amountWithoutFee = amount - 0.30;
            double answer = ratio * amountWithoutFee;
            return Convert.ToInt32(answer);
        }
        
        public void UpdateAccountBalance(string token, string id)
        {
            string accountId = JWTLogic.GetId(token);
            Account account = _accountData.GetAccountById(accountId);
            double amount = Convert.ToDouble(GetOrderInfo(id).Result.purchase_units[0].amount.value);
            _balanceData.UpdateAccountBalance(account, GetFeelessAmount(amount));
        }
    }
}