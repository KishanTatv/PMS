using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PMS.Entity;
using PMS.Entity.Models;

namespace PMS.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7071/api/");
        }

        public async Task<IActionResult> Index(PageCommonDto request)
        {
            List<ProductShowDto> data = new List<ProductShowDto>();
            HttpResponseMessage response = await _httpClient.GetAsync($"Admin/GetProduct?pageNumber={request.PageNumber}&pageSize={request.PageSize}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ApiResponse<List<ProductShowDto>>? apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductShowDto>>>(jsonResponse);
                data = apiResponse.Data;
            }
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response1 = await _httpClient.GetAsync($"Admin/GetCover?pageNumber=0&pageSize=10");
            HttpResponseMessage response2 = await _httpClient.GetAsync($"Admin/GetCategory?pageNumber=0&pageSize=10");
            IEnumerable<SelectListItem> coverList = new List<SelectListItem>();
            IEnumerable<SelectListItem> categoryList = new List<SelectListItem>();
            await response1.Content.ReadFromJsonAsync<ApiResponse<List<CoverDto>>>().ContinueWith(task =>
            {
                var apiResponse = task.Result;
                coverList = apiResponse.Data.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
                ViewBag.CoverList = coverList;
            });
            await response2.Content.ReadFromJsonAsync<ApiResponse<List<CategoryDto>>>().ContinueWith(task =>
            {
                var apiResponse = task.Result;
                categoryList = apiResponse.Data.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
                ViewBag.CategoryList = categoryList;
            });
            return View();
        }


        public IActionResult AddProduct(ProductDetailDto productDetailDto)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _httpClient.PostAsJsonAsync("Admin/AddUpdateProduct", productDetailDto).Result;
                ApiResponse<string>? apiResponse = response.Content.ReadFromJsonAsync<ApiResponse<string>>().Result;
                if (apiResponse != null && apiResponse.Result)
                {
                    return RedirectToAction("Index");
                }
                return View("Create");
            }
            return View("Create");
        }
    }
}
