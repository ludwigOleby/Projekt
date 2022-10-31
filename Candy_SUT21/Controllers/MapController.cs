using Candy_SUT21.Models.APIModels;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{

    public class MapController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MapController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Map(string cord1, string cord2)
        {
            
            Root model;


            var request = new HttpRequestMessage(HttpMethod.Get, $"https://atlas.microsoft.com/route/directions/json?api-version=1.0&query={cord1}:{cord2}&subscription-key=UXsLQk9ekQxPmWrI7dNLF7xq40X0qc9vS_ZVZlzCgAM");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClientFactory.CreateClient();
           
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadFromJsonAsync<Root>();
                string[] storageCord = cord1.Replace(" ", "").Split(",");
                string[] customerCord = cord2.Replace(" ", "").Split(",");

                var mapview = new MapViewModel() { distance = model.routes[0].summary.lengthInMeters, StorageCord = storageCord, CustomerCord = customerCord };
                    
                    return View(mapview);
                }
                else
                {
                    return NotFound();
                }
           

        }

    }

}
