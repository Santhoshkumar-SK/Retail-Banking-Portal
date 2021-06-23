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
    public class LoginController : Controller
    {
        string JwtToken;
        int id = 0;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly IEmployeeRepo _employeeRepo;
        private readonly ICustomerRepo _customerRepo;

        public LoginController(IEmployeeRepo employeeRepo, IHttpContextAccessor httpContextAccessor, ICustomerRepo customerRepo)
        {
            _employeeRepo = employeeRepo;
            _customerRepo = customerRepo;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Employee()
        {
            JwtToken = _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];
            if (JwtToken == null)
            {
                return View();
            }
            else
            {
                return Redirect("/Employee/employeeConsole");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Employee(UserDTO user)
        {
            if (ModelState.IsValid)
            {

                var jwtToken = await _employeeRepo.loginEmployee(user);
                if (jwtToken == null)
                {
                    ModelState.AddModelError("Role", "Credentials details is wrong");
                    return View(user);
                }
                else
                {
                    var options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                    };
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", jwtToken, options);
                
                    return Redirect("/Employee/employeeConsole");
                }

            }
            else
            {
                return View(user);
            }
        }




        public IActionResult Customer()
        {
            try
            {
                JwtToken = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
                id = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
                if (JwtToken == null)
                {
                    return View();
                }
                else
                {

                    var data = _customerRepo.getCustomerDetails(id);
                    return View("customerConsole", data);
                }
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Customer(UserDTO user)
        {
            if (ModelState.IsValid)
            {

                var jwtToken = await _customerRepo.loginCustomer(user);
                if (jwtToken == null)
                {
                    ModelState.AddModelError("Role", "Credentials details is wrong");
                    return View(user);
                }
                else
                {
                    var options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),
                    };
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("CustomerJwtToken", jwtToken, options);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("id", user.UserId.ToString(), options);
                    var data = _customerRepo.getCustomerDetails(user.UserId);
                    return View("customerConsole", data);
                }

            }
            else
            {
                return View(user);
            }
        }


        public IActionResult customerConsole()
        {
            string access = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
            if (access != null)
            {
                id = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
                List<CustomerAccount> data = _customerRepo.getCustomerDetails(id);
                return View(data);
            }
            return View("Customer");
        }

    }
}
