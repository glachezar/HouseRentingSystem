using HouseRentingSystem.Web.ViewModels.Category;

namespace HouseRentingSystem.Data.Services.Interfaces
{
    

    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();
    }
}
