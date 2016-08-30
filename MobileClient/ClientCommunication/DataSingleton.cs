using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
//addd a nuGet package, search for newtonsoft and choose Json.Net 9.x something from within MSVS

namespace MobileClient.ClientCommunication
{
    public class DataSingleton
    {

        private static readonly DataSingleton instance = new DataSingleton();

        private static HttpClient client;
        private static Uri uri;

        private DataSingleton() 
        {
            client = new HttpClient();
           
        }

        public void SetURI(string uriString) //e.g. http://localhost:5050
        {
            uri = new Uri(uriString);
            client.BaseAddress = uri;
        }

        private static async Task<T> DeserializeObject<T>(HttpResponseMessage responseMessage)
        {
                if (responseMessage.IsSuccessStatusCode)
                {
                    string clientResponse = await responseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(clientResponse);
                }
                else
                    return (T)(Object)null;
        }

        private static async Task<HttpResponseMessage> SerializeAndPostObject<T>(string requestURI, Object taskObject)
        {
            string objectToSend = JsonConvert.SerializeObject((T)taskObject);
            return await client.PostAsync(requestURI, new StringContent(objectToSend, Encoding.UTF8, "application/json"));
        }

        public static async Task<T> SendObject<T>(string requestURI, Object taskObject)
        {
            HttpResponseMessage responseMessage = await SerializeAndPostObject<T>(requestURI, taskObject);
            return await DeserializeObject<T>(responseMessage);
        }

        public static async Task<T[]> SendObjects<T>(string requestURI, List<Object> members)
        {
            return await Task.WhenAll(members.Select(x => SendObject<T>(requestURI, x)));
        }
    }
}