using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Job.DBModel;
using Job.Helper;
using Job.Settings;
using Microsoft.Extensions.Configuration;

namespace Job.YaHttpClient
{
    public class YandexHttpClient : IYandexHttpClient
    {
        public readonly AppSettings _settings;
        public readonly IHttpClientFactory _clientFactory;
        public YandexHttpClient(IConfiguration opt, IHttpClientFactory clientFactory)
        {
            _settings = ConfigurationHelper.GetAppSettings(opt);
            _clientFactory = clientFactory;
        }

        private HttpClient CreateCustomHttpClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("X-Yandex-API-Key", _settings.YandexWeather?.ApiKey);
            return client;
        }
        public async Task<string> GetWeatherByPlace(Place place)
        {
            Uri yaUri = new Uri(_settings.YandexWeather?.Url).AddParameter("lat", place.Latitude.ToString(new CultureInfo("en-US")))
                                                             .AddParameter("lon", place.Longitude.ToString(new CultureInfo("en-US")));
            var request = new HttpRequestMessage(HttpMethod.Get, HttpUtility.UrlDecode(yaUri.ToString()));
            var client = CreateCustomHttpClient(_clientFactory.CreateClient("YandexWeather"));
            var response = await client.SendAsync(request);

            if ( response.IsSuccessStatusCode )
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}