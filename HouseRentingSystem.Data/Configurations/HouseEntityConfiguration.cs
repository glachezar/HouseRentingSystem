namespace HouseRentingSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class HouseEntityConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder
                .HasOne(h => h.Categiry)
                .WithMany(h => h.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Agent)
                .WithMany(a => a.OwnedHousers)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            
            //builder
            //    .HasOne(h => h.Renter)
            //    .WithMany(r => r.RentedHouses)
            //    .HasForeignKey(h => h.RenterId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
