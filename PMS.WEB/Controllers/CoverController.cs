using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.Entity;
using PMS.Entity.Models;

namespace PMS.WEB.Controllers
{
    public class CoverController : Controller
    {
        private readonly HttpClient _httpClient;

        public CoverController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7071/api/");
        }

        public async Task<IActionResult> Index(PageCommonDto request)
        {
            List<CoverDto> data = new List<CoverDto>();
            HttpResponseMessage response = await _httpClient.GetAsync($"Admin/GetCover?pageNumber={request.PageNumber}&pageSize={request.PageSize}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ApiResponse<List<CoverDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<CoverDto>>>(jsonResponse);
                data = apiResponse.Data;
            }
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddCover(CoverDto coverDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            HttpResponseMessage response = _httpClient.PostAsJsonAsync("Admin/AddUpdateCover", coverDto).Result;
            ApiResponse<string>? apiResponse = response.Content.ReadFromJsonAsync<ApiResponse<string>>().Result;
            if (apiResponse != null && apiResponse.Result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
