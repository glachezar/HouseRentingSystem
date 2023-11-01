namespace HouseRentingSystem.Data.Services.Interfaces
{
    

    public interface IAgentService
    {
        Task<bool> AgentExistByUserIdAsync(string userId);
    }
}
