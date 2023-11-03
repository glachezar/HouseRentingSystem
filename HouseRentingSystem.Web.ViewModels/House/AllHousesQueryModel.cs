namespace HouseRentingSystem.Web.ViewModels.House
{
    using System.ComponentModel;

    using Enums;

    using static Common.GeneralApplicationConstants;

    public class AllHousesQueryModel
    {
        public AllHousesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.HousesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Houses = new HashSet<HouseAllViewModel>();
        }


        public string? Category { get; set; }

        [DisplayName("Search by word")]
        public string? SearchString { get; set; }

        [DisplayName("Sort Houses By")]
        public HouseSorting HouseSorting { get; set; }

        public int CurrentPage { get; set; }

        public int HousesPerPage { get; set; }

        public int TotalHousesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<HouseAllViewModel> Houses { get; set; }
    }
}
