using Microsoft.AspNetCore.Mvc;

namespace MWayV2.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://us-weather-by-zip-code.p.rapidapi.com/getweatherzipcode?zip=94111"),
                Headers =
            {
                { "X-RapidAPI-Host", "us-weather-by-zip-code.p.rapidapi.com" },
                { "X-RapidAPI-Key", "c2c238f8e0msh7047b245fcf87b9p13983cjsn2f8b1544afe6" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }

            return View();
        }



    }
}
