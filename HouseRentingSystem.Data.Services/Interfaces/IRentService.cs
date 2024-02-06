namespace HouseRentingSystem.Data.Services.Interfaces;

using Web.ViewModels.Rent;

public interface IRentService
{
    Task<IEnumerable<RentViewModel>> AllAsync();
}
