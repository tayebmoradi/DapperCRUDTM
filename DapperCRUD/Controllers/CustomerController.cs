using DapperCRUD.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository) 
        {
           _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _customerRepository.GetAllAsync();
            return View(result);
        }
    }
}
