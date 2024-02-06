namespace HouseRentingSystem.Data.Services.Interfaces;

using Web.ViewModels.User;

public interface IUserService
{
    Task<string> GetFullNameByEmailAsync(string email);

    Task<string> GetFullNameByIdAsync(string userId);

    Task<IEnumerable<UserViewModel>> AllAsync();
}
