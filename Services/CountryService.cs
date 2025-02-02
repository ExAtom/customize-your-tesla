﻿using System;
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
        private const string apiUrl = "https://restcountries.com/v2/all?fields=callingCodes,flag,nativeName,alpha3Code";

        private static HttpClient httpClient = new HttpClient();

        public static List<CountryInfo> CachedCountryInfos;

        public static async Task<List<CountryInfo>> FetchCountryInfos()
        {
            var response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            List<CountryInfo> countryInfos = JsonSerializer.Deserialize<List<CountryInfo>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            CachedCountryInfos = countryInfos;
            return countryInfos;
        }

        public static async Task<string> DownloadFlag(IFlag flag)
        {
            var response = await httpClient.GetAsync(flag.Flag);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
