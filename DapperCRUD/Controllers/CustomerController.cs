using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
