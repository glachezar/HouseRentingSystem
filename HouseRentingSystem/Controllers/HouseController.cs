namespace HouseRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data.Services.Interfaces;
    using Infrastructure.Extentions;
    using ViewModels.House;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class HouseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;

        public HouseController(ICategoryService categoryService, IAgentService agentService)
        {
            this.categoryService = categoryService;
            this.agentService = agentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isAgent = await agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
                return this.RedirectToAction("Become", "Agent");
            }

            HouseFormModel model = new HouseFormModel()
            {
                Categories = await categoryService.AllCategoriesAsync()
            };
            return this.View(model);
        }
    }
}
