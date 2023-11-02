using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Data.Services.Interfaces
{
    using HouseRentingSystem.Web.ViewModels.Home;

    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

        Task CreateAsync(HouseFormModel model, string agentId);
    }
}
