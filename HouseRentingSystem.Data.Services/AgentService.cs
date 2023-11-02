namespace HouseRentingSystem.Data.Services
{
    using HouseRentingSystem.Data.Models;
    using HouseRentingSystem.Data.Services.Interfaces;
    using HouseRentingSystem.Web.ViewModels.Agent;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext dbContext;

        public AgentService(HouseRentingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber)
        {
            bool agentExist = await this.dbContext
                 .Agents
                 .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return agentExist;
        }

        public async Task<bool> AgentExistByUserIdAsync(string userId)
        {
            bool agentExist = await this.dbContext
                .Agents
                .AnyAsync(a => a.UserId.ToString() == userId);

            return agentExist;
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task CreateAsync(string userId, BecomeAgentFormModel model)
        {
            Agent newAgent = new Agent()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Agents.AddAsync(newAgent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetAgentIdByUserIdAsync(string userId)
        {
            Agent? agent = await this.dbContext
                .Agents
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (agent == null)
            {
                return null;
            }

            return agent.Id.ToString();
        }
    }
}
