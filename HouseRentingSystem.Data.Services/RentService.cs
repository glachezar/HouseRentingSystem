﻿namespace HouseRentingSystem.Data.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Interfaces;
using Service.Mapping;
using Web.ViewModels.Rent;

public class RentService : IRentService
{
    private readonly HouseRentingDbContext dbContext;

    public RentService(HouseRentingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<RentViewModel>> AllAsync()
    {
        IEnumerable<RentViewModel> allRents = await this.dbContext
            .Houses
            .Include(h => h.Renter)
            .Include(h => h.Agent)
            .ThenInclude(a => a.User)
            .Where(h => h.RenterId.HasValue)
            .To<RentViewModel>()
            .ToArrayAsync();

        return allRents;
    }
}