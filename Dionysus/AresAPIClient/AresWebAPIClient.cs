using Dionysus.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dionysus.AresAPIClient
{
    public class AresWebAPIClient
    {
        private static string localURL = "http://localhost:8888";
        private static string azureURL = "http://auctionwebapp.azurewebsites.net";

        public static async Task<List<AuctionItem>> FetchActiveAuctionItems()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string hostURL = localURL + "/api/AuctionItemsAPI";
            var streamTask = client.GetStreamAsync(hostURL);
            var serializer = new DataContractJsonSerializer(typeof(List<AuctionItem>));
            var activeAuctionItems = serializer.ReadObject(await streamTask) as List<AuctionItem>;
            return activeAuctionItems;                        
        }

        public static async Task<HttpResponseMessage> SubmitOffer(string offerJson)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string hostURL = localURL + "/api/OffersAPI";
            HttpResponseMessage response = await client.PostAsync(hostURL, new StringContent(offerJson, Encoding.UTF8, "application/json"));
            return response;
        }
    }



}
