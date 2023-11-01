﻿namespace HouseRentingSystem.Data.Services.Interfaces
{
    using HouseRentingSystem.Web.ViewModels.Agent;

    public interface IAgentService
    {
        Task<bool> AgentExistByUserIdAsync(string userId);

        Task<bool> AgentExistByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasRentsByUserIdAsync(string userId);

        Task CreateAsync(string userId, BecomeAgentFormModel model);
    }
}