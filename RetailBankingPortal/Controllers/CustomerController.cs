using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailBankingPortal.Models;
using RetailBankingPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailBankingPortal.Controllers
{
    public class CustomerController : Controller
    {
        //Global Variables
        string JwtToken;
        int id = 0;
        int sourceid = 0;
        //**//

        HttpClient client = new HttpClient();

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ICustomerRepo _repo;

        public CustomerController(ICustomerRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult logoutCustomer()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("CustomerJwtToken");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("id");
            return Redirect("/Login/Customer");
        }
       
        public IActionResult transaction()
        {
            string access = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
            if (access != null)
            {
                int id = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
                List<CustomerAccount> customerAccount = _repo.getCustomerDetails(id);
                sourceid = customerAccount.First().accountId;
                ViewData["accid"] = sourceid;

                return View();
            }
            return Redirect("/Login/Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> transaction([Bind("sourceAccountId,destinationAccountId,amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                
               
                AfterTransaction data = await _repo.getTransaction(transaction);
                
                if (data.message != "Transaction Success")
                {
                    ModelState.AddModelError("amount", data.message);
                    return View(transaction);
                }

                ViewBag.SuccessfullCreation = $"{data.message}!!\nSuccessfully Sended Rs.{transaction.amount} to Receiver(Receiver Accountid :{transaction.destinationAccountId})\n Available Balance : Rs.{data.sourceAccountBalance}";
                ViewData["accid"] = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
                return View();
            }
            ViewData["accid"] = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
            return View(transaction);
        }

        public IActionResult transactionHistory()
        {
            string access = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
            if(access != null)
            {
                var data = _repo.getTransactionHistory();

                return View(data);
            }

            return Redirect("/Login/Customer");
        }

        public IActionResult statement()
        {
            string access = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
            if(access != null)
            {
                List<Statement> statements = _repo.GetStatements();

                return View(statements);
            }

            return Redirect("/Login/Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult statement([Bind("AccountId,FromDate,ToDate")] StatementSearch search)
        {
            List<Statement> statements = _repo.GetStatementsWithDate(search);
            return View(statements);
        }
    }
}
