using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static Candy_SUT21.Models.APIModels.GreetingsApiModel;

namespace Candy_SUT21.Services
{
    public class GreetingsApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        public GreetingsApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string[]> GetRandomGreeting()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.greetingsapi.com/random");
            var client = _clientFactory.CreateClient();
            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var greetingModel = await response.Content.ReadFromJsonAsync<GreetingModel>();
                    return new string[] { greetingModel.greeting, greetingModel.language };
                }
                else
                    return new string[] { "Hello", "English" };
            }
            catch
            {
                return new string[] { "Hello", "English" };
            }
        }
    }
}
