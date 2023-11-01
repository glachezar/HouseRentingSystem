namespace HouseRentingSystem.Data.Services
{
    using HouseRentingSystem.Data.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext dbContext;

        public AgentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistByUserIdAsync(string userId)
        {
            bool agentExist = await this.dbContext
                .Agents
                .AnyAsync(a => a.UserId.ToString() == userId);

            return agentExist;
        }
    }
}
