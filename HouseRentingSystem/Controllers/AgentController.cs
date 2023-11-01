namespace HouseRentingSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AgentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string userId = 
            return View();
        }
    }
}
