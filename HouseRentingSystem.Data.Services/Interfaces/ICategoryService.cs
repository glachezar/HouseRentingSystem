namespace HouseRentingSystem.Data.Services.Interfaces
{

    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> CategoryExistByIdAsync(int id);
    }
}
