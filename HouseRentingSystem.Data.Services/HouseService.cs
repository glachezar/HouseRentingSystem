namespace HouseRentingSystem.Data.Services
{
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Services.Interfaces;
    using HouseRentingSystem.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext dbContext;

        public HouseService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
            throw new NotImplementedException();
        }
    }
}