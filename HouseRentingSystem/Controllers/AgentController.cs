namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Data.Services.Interfaces;
    using HouseRentingSystem.Web.Infrastructure.Extentions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistByUserIdAsync(userId);

            if (isAgent)
            {
                TempData[ErrorMessage] = "You are already an agent!";

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
