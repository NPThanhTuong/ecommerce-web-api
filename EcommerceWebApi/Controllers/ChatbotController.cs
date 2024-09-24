using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EcommerceWebApi.Controllers
{
    public class ChatbotController : Controller
    {
        private readonly HttpClient _httpClient;

        public ChatbotController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            var rasaUrl = "http://localhost:5005/webhooks/rest/webhook";


            var payload = new
            {
                sender = "user",
                message = message
            };


            var response = await _httpClient.PostAsJsonAsync(rasaUrl, payload);


            var content = await response.Content.ReadAsStringAsync();
            var responseMessages = JArray.Parse(content);


            var rasaResponse = string.Join(" ", responseMessages.Select(m => m["text"]?.ToString()));

            return Json(new { response = rasaResponse });
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
