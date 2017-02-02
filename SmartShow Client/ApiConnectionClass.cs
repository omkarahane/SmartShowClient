using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace SmartShow_Client
{
    public class ApiConnectionClass<T> where T:class
    {
       static HttpClient client;
        public ApiConnectionClass(HttpClient _client)
        {
            client = _client;
        }

        public async Task<List<T>> CallGetAPiReturningList(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            List<T> product = null;
            if (response.IsSuccessStatusCode)
            {
             var  productList = await response.Content.ReadAsAsync<T>();
            }
            return product;
        }
        public async Task<T> CallGetAPi(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            T product=null;
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<T>();
            }
            return product;
        }

        public async Task<bool> CallPostAPi(string path,T model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, model);
            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}