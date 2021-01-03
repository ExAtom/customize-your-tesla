using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TeslaCarConfigurator.Services
{
    public static class CountryService
    {
        private const string apiUrl = "https://restcountries.eu/rest/v2/all?fields=callingCodes;flag;nativeName;alpha3Code";

        private static HttpClient httpClient = new HttpClient();

        public static async Task<CountryInfo[]> FetchCountryInfos()
        {
            var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            CountryInfo[] countryInfos = JsonSerializer.Deserialize<CountryInfo[]>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return countryInfos;
        }

        public static async Task<string> DownloadFlag(CountryInfo country)
        {
            var response = await httpClient.GetAsync(country.Flag);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
