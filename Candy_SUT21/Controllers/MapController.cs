using Candy_SUT21.Models;
using Candy_SUT21.Models.APIModels;
using Candy_SUT21.Services;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{

    public class MapController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GeocodingApiService _geocodingService;
        private readonly IOrderRepository _orderRepository;

        public MapController(IHttpClientFactory httpClientFactory,
                GeocodingApiService geocodingApi,
                IOrderRepository orderRepository)
        {
            _httpClientFactory = httpClientFactory;
            _geocodingService = geocodingApi;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> GetCustomerCoordinates(int id)
        {
            var order = _orderRepository.GetOrderDetails(id);
            var zip = order.ZipCode;
            var city = order.City;
            var street = order.Address.Remove(order.Address.LastIndexOf(" "));
            var housenumber = order.Address.Substring(order.Address.LastIndexOf(" "));

            double[] coordinates = await _geocodingService.GetCustomerCoordinates(zip, city, housenumber, street);


            return RedirectToAction("Map", new { customerCoordinates = coordinates });
        }


        public async Task<IActionResult> Map(double[] customerCoordinates)
        {
            for (int i = 0; i < customerCoordinates.Length; i++)
            {
                customerCoordinates[i] = Math.Round(customerCoordinates[i], 5);
            }


            string storage = "57.09722,12.27333";
            string[] storageCord = new string[]
            {
                "57.09488",
                "12.25470"
            };
            string[] customerCord = new string[]
            {
                customerCoordinates[0].ToString().Replace(",","."),
                customerCoordinates[1].ToString().Replace(",", ".")
            };

            string destination = Math.Round(customerCoordinates[0], 5).ToString().Replace(",", ".") + "," + Math.Round(customerCoordinates[1], 5).ToString().Replace(",", ".");

            Root model;


            var request = new HttpRequestMessage(HttpMethod.Get, $"https://atlas.microsoft.com/route/directions/json?api-version=1.0&query={storage}:{destination}&instructionsType=text&routeRepresentation=summaryOnly&subscription-key=UXsLQk9ekQxPmWrI7dNLF7xq40X0qc9vS_ZVZlzCgAM");
            request.Headers.Add("Accept", "application/json");
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadFromJsonAsync<Root>();


                var mapview = new MapViewModel()
                {
                    distance = model.routes[0].summary.lengthInMeters/1000,
                    StorageCord = storageCord,
                    CustomerCord = customerCord,
                    departureTime = model.routes[0].summary.departureTime,
                    arrivalTime = model.routes[0].summary.arrivalTime,
                    guidance = model.routes[0].guidance,
                };


                return View(mapview);
            }
            else
            {
                return NotFound();
            }


        }

    }

}
