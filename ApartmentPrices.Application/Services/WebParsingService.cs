using ApartmentPrices.Domain.Abstractions.Services;
using ApartmentPrices.Domain.Models;
using Newtonsoft.Json.Linq;

namespace ApartmentPrices.Application.Services
{
    public class WebParsingService : IWebParsingService
    {
        public async Task<decimal> GetPriceByUrl(string url)
        {
            using (var client = new HttpClient())
            {
                using var result = await client.GetAsync(url + "?ajax=1");
                var json = await result.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);
                string? price = data["price"]?.ToString();
                return decimal.Parse(price);
            }
        }

        public async Task<string> GetStatusByUrl(string url)
        {
            using (var client = new HttpClient())
            {
                using var result = await client.GetAsync(url + "?ajax=1");
                var json = await result.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);
                var status = data["status"]["type"].ToString();

                return status ?? "";
            }
        }

        public async Task<(string Address, decimal Price, string Status)> GetInfo(string url)
        {
            using (var client = new HttpClient())
            {
                using var result = await client.GetAsync(url + "?ajax=1");
                var json = await result.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);
                string? address = data["locationAddress"]?.ToString();
                decimal price = decimal.Parse(data["price"]?.ToString());
                var status = data["status"]["type"].ToString();

                return (address ?? "", price, status);
            }
        }
    }
}
