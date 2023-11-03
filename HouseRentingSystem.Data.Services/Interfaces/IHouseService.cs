namespace HouseRentingSystem.Data.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.House;
    using Web.ViewModels.Home;
    using Web.ViewModels.House;


    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

        Task CreateAsync(HouseFormModel model, string agentId);

        Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel queryModel);
    }
}
