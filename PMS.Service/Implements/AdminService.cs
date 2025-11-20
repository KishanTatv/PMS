using Microsoft.AspNetCore.Mvc;
using PMS.Common;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implements
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<JsonResult> GetCategory(PageCommonDto requestData)
        {
            IEnumerable<CategoryDto> categoryList = await _adminRepository.GetCategory(requestData);
            return JsonResponse.SuccessResponse(categoryList, string.Format(Messages.success, "Category list", "retrived"));
        }

        public async Task<JsonResult> GetCategoryById(int categoryId)
        {
            CategoryDto category = await _adminRepository.GetCategoryById(categoryId);
            return JsonResponse.SuccessResponse(category, string.Format(Messages.success, "Category detail", "retrived"));
        }

        public async Task<JsonResult> AddCategory(CategoryDto requestModel)
        {
            int rowCount = await _adminRepository.AddNewCategory(requestModel);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "add", "new category"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "New category", "added"));
        }

        public async Task<JsonResult> DeleteCategory(int categoryId)
        {
            int rowCount = await _adminRepository.DeleteCategory(categoryId);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "delete", "category"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Category", "deleted"));
        }

        public async Task<JsonResult> GetCover(PageCommonDto requestData)
        {
            IEnumerable<CoverDto> coverList = await _adminRepository.GetCover(requestData);
            return JsonResponse.SuccessResponse(coverList, string.Format(Messages.success, "Cover list", "retrived"));
        }

        public async Task<JsonResult> GetCoverById(int coverId)
        {
            CoverDto cover = await _adminRepository.GetCoverById(coverId);
            return JsonResponse.SuccessResponse(cover, string.Format(Messages.success, "Cover detail", "retrived"));
        }

        public async Task<JsonResult> AddUpdateCover(CoverDto requestModel)
        {
            int rowCount = await _adminRepository.AddUpdateCover(requestModel);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, requestModel.Id > 0 ? "update" : "add", "cover"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Cover", requestModel.Id > 0 ? "update" : "add"));
        }

        public async Task<JsonResult> DeleteCover(int coverId)
        {
            int rowCount = await _adminRepository.DeleteCover(coverId);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "delete", "cover"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Cover", "deleted"));
        }

        public async Task<JsonResult> GetProduct(PageCommonDto requestData)
        {
            IEnumerable<ProductShowDto> productList = await _adminRepository.GetProduct(requestData);
            return JsonResponse.SuccessResponse(productList, string.Format(Messages.success, "Product list", "retrived"));
        }

        public async Task<JsonResult> CheckExistingProduct(string name, int id)
        {
            bool isExist = await _adminRepository.CheckExistingProduct(name, id);
            return JsonResponse.SuccessResponse(isExist, string.Empty);
        }

        public async Task<JsonResult> GetProductById(int productId)
        {
            ProductDetailDto product = await _adminRepository.GetProductById(productId);
            return JsonResponse.SuccessResponse(product, string.Format(Messages.success, "Product detail", "retrived"));
        }

        public async Task<JsonResult> AddUpdateProduct(ProductDetailDto requestModel)
        {
            int rowCount = await _adminRepository.AddUpdateProduct(requestModel);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, requestModel.Id > 0 ? "update" : "add", "product"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Product", requestModel.Id > 0 ? "update" : "add"));
        }

        public async Task<JsonResult> DeleteProduct(int productId)
        {
            int rowCount = await _adminRepository.DeleteProduct(productId);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "delete", "product"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Product", "deleted"));
        }
    }
}
