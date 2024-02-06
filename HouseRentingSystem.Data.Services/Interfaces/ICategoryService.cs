namespace HouseRentingSystem.Data.Services.Interfaces;

using Web.ViewModels.Category;

public interface ICategoryService
{
    Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

    Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();

    Task<bool> ExistsByIdAsync(int id);

    Task<IEnumerable<string>> AllCategoryNamesAsync();

    Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);
}
