using DapperCRUD.Models;
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

        public async Task<IActionResult> Details(int id)
        {
            var result = await _customerRepository.GetByIdAsync(id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {

                await _customerRepository.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.Id = id;

                    await _customerRepository.Update(customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var _Branch = await _customerRepository.GetByIdAsync(id);
            return View(_Branch);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
