using Newtonsoft.Json;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Utility
{
    public class PharmacyService
    {
        const string Url = "http://pharmacyapiprototype123.azurewebsites.net/api/products";

        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех друзей
        public async Task<IEnumerable<Product>> Get()
        {

           HttpClient client = GetClient();
           string result = await client.GetStringAsync(Url);
           return JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
           
        }

    }
}
