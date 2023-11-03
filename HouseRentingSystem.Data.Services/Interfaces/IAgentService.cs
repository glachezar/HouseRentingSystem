﻿namespace HouseRentingSystem.Data.Services.Interfaces
{
    using Web.ViewModels.Agent;

    public interface IAgentService
    {
        Task<bool> AgentExistByUserIdAsync(string userId);

        Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasRentsByUserIdAsync(string userId);

        Task CreateAsync(string userId, BecomeAgentFormModel model);

        Task<string?> GetAgentIdByUserIdAsync(string userId);
    }
}
