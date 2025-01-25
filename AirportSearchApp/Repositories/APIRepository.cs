using AirportSearchApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AirportSearchApp.Repositories
{
    public class APIRepository
    {
        public APIRepository() { }

        public async Task<AirportModel> GetResponseAPI(string airportname)
        {
            string url = $"https://freetestapi.com/api/v1/airports?search={airportname}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        List<AirportModel> responseAsList = (await response.Content.ReadFromJsonAsync<List<AirportModel>>())!;

                        var firstAirport = responseAsList.FirstOrDefault();

                        if (firstAirport != null)
                        {
                            return firstAirport;
                        }

                        return null;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
