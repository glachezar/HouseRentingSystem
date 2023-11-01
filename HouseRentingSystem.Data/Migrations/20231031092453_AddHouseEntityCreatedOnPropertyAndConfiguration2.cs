using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddHouseEntityCreatedOnPropertyAndConfiguration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("4e95ff17-e51f-48ef-acd7-75d5e2b7960a"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("54913732-8cbb-42db-898f-94b4cb316e4a"), 3, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("bb655301-f6f9-45c4-ba83-c32a6e6797d5"), "North London UK (Near the border)", new Guid("54913732-8cbb-42db-898f-94b4cb316e4a"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 2100.00m, new Guid("39b37ebc-8346-44cd-dc90-08dbd81d7952"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("bda47b58-213b-4261-9e38-5c76f73ed28d"), "167th Ave, Homestead, Florida", new Guid("54913732-8cbb-42db-898f-94b4cb316e4a"), 3, "Incredible Florida Mega Mansion Surrounded by Water", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Chateau Artisan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4e95ff17-e51f-48ef-acd7-75d5e2b7960a"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("bb655301-f6f9-45c4-ba83-c32a6e6797d5"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("bda47b58-213b-4261-9e38-5c76f73ed28d"));
        }
    }
}
