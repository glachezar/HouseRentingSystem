namespace HouseRentingSystem.Web.ViewModels.House
{
    using System.ComponentModel;


    public class HouseAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        [DisplayName("Image Url")] 
        public string ImageUrl { get; set; } = null!;

        [DisplayName("Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; set; }
    }
}
