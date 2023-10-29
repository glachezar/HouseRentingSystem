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


        private House[] GenerateHouses()
        {
            ICollection<House> houses = new HashSet<House>();

            House house;
            house = new House()
            {
                Title = "Big House Marina",
                Address = "North London UK (Near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("54913732-8cbb-42db-898f-94b4cb316e4a"),
                RenterId = Guid.Parse("39B37EBC-8346-44CD-DC90-08DBD81D7952")
            };
            houses.Add(house);

            house = new House()
            {
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/99907039.jpg?k=775d8e3b0f25aeb4a9f4e16513feca65dfa1b7e9778729619d73c2675d9d96f5&o=&hp=1",
                PricePerMonth = 1200.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("54913732-8cbb-42db-898f-94b4cb316e4a"),
                
            };
            houses.Add(house);

            house = new House()
            {
                Title = "Chateau Artisan",
                Address = "167th Ave, Homestead, Florida",
                Description = "Incredible Florida Mega Mansion Surrounded by Water",
                ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2022/10/main.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("54913732-8cbb-42db-898f-94b4cb316e4a"),

            };
            houses.Add(house);

            return houses.ToArray();
        }
    }
}
