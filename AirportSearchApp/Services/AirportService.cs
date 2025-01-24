using System.Net.Http.Json;
using AirportSearchApp.Models;

namespace AirportSearchApp.Services;

public class AirportService
{
    private const string ApiUrl = "https://freetestapi.com/api/v1/airports?search=";

    public async Task<Airport?> GetAirportAsync(string search)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"{ApiUrl}{search}&limit=1");

        if (response.IsSuccessStatusCode)
        {
            var airports = await response.Content.ReadFromJsonAsync<List<Airport>>();
            return airports?.FirstOrDefault();
        }

        return null;
    }
}
