using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
