using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Data.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data;
    using Services.Interfaces;
    using Web.ViewModels.Home;

    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext dbContext;

        public HouseService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
            IEnumerable<IndexViewModel> lastThreeHouses = await this.dbContext
                .Houses
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel()
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeHouses;
        }

        public async Task CreateAsync(HouseFormModel model, string agentId)
        {
            House newHouse = new House
            {
                Title = model.Title,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = Guid.Parse(agentId),
            };

            await dbContext.Houses.AddAsync(newHouse);
            await dbContext.SaveChangesAsync();
        }
    }
}