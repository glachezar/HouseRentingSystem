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
        private readonly IHouseService houseService;

        public HouseController(ICategoryService categoryService, IAgentService agentService, IHouseService houseService)
        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.houseService = houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            //TODO: Implement it!
            return this.Ok();
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

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            bool isAgent = await agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new houses!";
                return this.RedirectToAction("Become", "Agent");
            }

            bool categoryExist = await this.categoryService.CategoryExistByIdAsync(model.CategoryId);
            if (!categoryExist)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");

            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
                await this.houseService.CreateAsync(model, agentId!);
            }
            catch (Exception _)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house. Please try again later or contact administrator!");
                model.Categories = await categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            //TODO: to change redirection to House Details page.
            return this.RedirectToAction("All", "House");
        }
    }
}
