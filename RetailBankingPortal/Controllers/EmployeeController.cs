using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailBankingPortal.Models;
using RetailBankingPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Controllers
{
    public class EmployeeController : Controller
    {

       

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IEmployeeRepo _repo;

        public EmployeeController(IEmployeeRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            this._httpContextAccessor = httpContextAccessor;
        }


        public IActionResult employeeConsole()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult employeeConsole([Bind("customerId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                int id = customer.customerId;
                var data = _repo.getCustomerDetails(id);
                if (data == null)
                {
                    ModelState.AddModelError("customerId", "InValid ID");
                    ViewData["id"] = customer.customerId;
                    return View(customer);
                }
                return View("customerDetails", data);
            }
            return View();
        }
        public IActionResult customerDetails(Customer customer)
        {
           
            return View(customer);
        }


        public IActionResult createCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createCustomer([Bind("customerName,customerDOB,customerAddress,customerPannumber,customerAdhaarnumber,customerAccountType")] CreateCustomer createCustomer)
        {

            if (ModelState.IsValid)
            {
                CreateCustomerResponse response = await _repo.createCustomer(createCustomer);
                if (response == null)
                {
                    return View(createCustomer);
                }
                ViewBag.SuccessfullCreation = "Your Customer ID is " + response.customerId + " and Account ID is " + response.accountId;
                return View();
            }
            return View(createCustomer);
        }


        public IActionResult logoutEmployee()
        {

            _httpContextAccessor.HttpContext.Response.Cookies.Delete("JwtToken");
            return Redirect("/Login/Employee");
        }
    }
}
