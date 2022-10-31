using Candy_SUT21.Models;
using Candy_SUT21.Models.APIModels;
using Candy_SUT21.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candy_SUT21.Services
{
    public class WeatherApiService
    {
        private readonly IHttpClientFactory _clientFactory;

        public WeatherApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<OrderWeather> GetOrderWeatherByLatLon(double lat, double lon, Order order)
        {
            WeatherApiModel weather;


            string lo = $"{lon:F6}".Replace(',', '.');
            string la = $"{lat:F6}".Replace(',', '.');



            var request = new HttpRequestMessage(HttpMethod.Get, "https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/" + lo + "/lat/" + la+ "/data.json");
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();


            var response = await client.SendAsync(request);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    weather = await response.Content.ReadFromJsonAsync<WeatherApiModel>();
                    OrderWeather orderWeather = new OrderWeather
                    {
                        OrderId = order.OrderId,
                        WeatherSymbol = weather.TimeSeries[0].Parameters.First(p => p.Name == "Wsymb2").Values[0],
                        RainMean = weather.TimeSeries[0].Parameters.First(p => p.Name == "pmean").Values[0],
                        Temperature = weather.TimeSeries[0].Parameters.First(p => p.Name == "t").Values[0],
                    };

                    return orderWeather;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
