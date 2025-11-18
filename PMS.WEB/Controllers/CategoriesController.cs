using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.Entity;
using PMS.Entity.Models;

namespace PMS.WEB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoriesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7071/api/");
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

        public async Task<IActionResult> Create(int categoryId)
        {
            CategoryDto categoryDto = new CategoryDto();
            if (categoryId > 0)
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"Admin/GetCategoryById?categoryId={categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    ApiResponse<CategoryDto>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<CategoryDto>>(jsonResponse);
                    categoryDto = apiResponse.Data;
                }
            }
            return View(categoryDto);
        }

        public IActionResult IsCategoryNameInUse(string name)
        {
            if (name.ToLower() == "Test".ToLower())
            {
                return Json($"Category name '{name}' is already in use.");
            }
            return Json(true);
        }

        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            HttpResponseMessage response = _httpClient.PostAsJsonAsync("Admin/AddCategory", categoryDto).Result;
            ApiResponse<string>? apiResponse = response.Content.ReadFromJsonAsync<ApiResponse<string>>().Result;
            if (apiResponse != null && apiResponse.Result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync($"Admin/DeleteCategory?categoryId={categoryId}").Result;
            ApiResponse<string>? apiResponse = response.Content.ReadFromJsonAsync<ApiResponse<string>>().Result;
            if (apiResponse != null && apiResponse.Result)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
