using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.WEB.Models;
using System.Diagnostics;

namespace PMS.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7071/api/");
            _logger = logger;
        }

        public async Task<IActionResult> Index(PageCommonDto request)
        {
            List<CategoryDto> data = new List<CategoryDto>();
            HttpResponseMessage response = await _httpClient.GetAsync($"Admin/GetCategory?pageNumber={request.PageNumber}&pageSize={request.PageSize}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ApiResponse<List<CategoryDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<CategoryDto>>>(jsonResponse);
                data = apiResponse.Data;
            }
            return View(data);
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
