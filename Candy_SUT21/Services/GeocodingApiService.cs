using Candy_SUT21.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candy_SUT21.Services
{
    public class GeocodingApiService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GeocodingApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<double[]> GetCoordinatesByZipcodeAndCity(string postalCode, string city)
        {
            GeocodingAPIModel position;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.geoapify.com/v1/geocode/search?postcode=" + postalCode + "&city=" + city + "&format=json&apiKey=67d29a448af8443b9f3bd2f1f4de813c");
            request.Headers.Add("Accept", "application/json");
            var client = _clientFactory.CreateClient();


            var response = await client.SendAsync(request);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    position = await response.Content.ReadFromJsonAsync<GeocodingAPIModel>();

                    if (position?.Results != null)
                    {
                        double[] coordinates = new double[2]
                        {
                            position.Results[0].Lat,
                            position.Results[0].Lon
                        };

                        return coordinates;
                    }

                    return null;

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
