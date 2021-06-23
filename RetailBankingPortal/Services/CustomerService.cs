using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RetailBankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailBankingPortal.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _config;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> loginCustomer(UserDTO user)
        {

            string token = null;
            HttpResponseMessage result = loginCustomerResponse(user);

            if (result.IsSuccessStatusCode)
            {
                var apiResponse = await result.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<string>(apiResponse);


            }

            return token;
        }

        public HttpResponseMessage loginCustomerResponse(UserDTO user)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            string uriConn = _config.GetValue<string>("ClientConnection:authorizationApiCon");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn + "api/Authentication/Login");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync<UserDTO>(client.BaseAddress, user);
                    response.Wait();
                    result = response.Result;

                }
                catch (Exception e)
                {

                    return null;
                }

            }



            return result;
        }


        public List<CustomerAccount> getCustomerDetails(int id)
        {



            CustomerAccount customerAccount = new CustomerAccount();

            HttpResponseMessage response = getCustomerResponse(id);

            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;

                var list = JsonConvert.DeserializeObject<List<CustomerAccount>>(result1);


                return list;


            }


            return null;

        }





        public HttpResponseMessage getCustomerResponse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_config.GetValue<string>("ClientConnection:accountApiCon"));
                
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"api/AccountManagement/getCustomerAccounts?customerId={id}";
                HttpResponseMessage response = client.GetAsync(url).Result;

                return response;
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }




        public List<TransactionHistory> getTransactionHistory()
        {



            TransactionHistory transactionHistory = new TransactionHistory();
            int id = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
            HttpResponseMessage response = getTransactionHistoryResponse(id);

            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;

                var list = JsonConvert.DeserializeObject<List<TransactionHistory>>(result1);


                return list;


            }


            return null;

        }





        public HttpResponseMessage getTransactionHistoryResponse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_config.GetValue<string>("ClientConnection:transactionApiCon"));
                var token = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
              
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"api/Transactions/getTransactions?customerId={id}";
                HttpResponseMessage response = client.GetAsync(url).Result;

                Console.WriteLine($"{id},{token},{response}");
                return response;
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }

        public async Task<AfterTransaction> getTransaction(Transaction transaction)
        {
           
            AfterTransaction data = new AfterTransaction();
            HttpResponseMessage result = getTransactionResponse(transaction);

            if (result.IsSuccessStatusCode)
            {
                var apiResponse = await result.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<AfterTransaction>(apiResponse);

                return data;
            }
            else
            {
                var apiResponse = await result.Content.ReadAsStringAsync();
               data.message = JsonConvert.DeserializeObject<string>(apiResponse);

                return data;
            }

          
        }

        public HttpResponseMessage getTransactionResponse(Transaction transaction)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            string uriConn = _config.GetValue<string>("ClientConnection:transactionApiCon");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn + "api/Transactions/transfer");
                var token = _httpContextAccessor.HttpContext.Request.Cookies["CustomerJwtToken"];
               
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync<Transaction>(client.BaseAddress, transaction);
                    response.Wait();
                    result = response.Result;

                }
                catch (Exception e)
                {

                    return null;
                }

            }



            return result;
        }



        public List<Statement> getStatements()
        {



            Statement statement = new Statement();
            int id = int.Parse(_httpContextAccessor.HttpContext.Request.Cookies["id"]);
            int accid = 0;
            List<CustomerAccount> customerAccount = getCustomerDetails(id);

            accid = customerAccount.First().accountId;
            HttpResponseMessage response = getStatementsResponse(accid);

            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;

                var list = JsonConvert.DeserializeObject<List<Statement>>(result1);


                return list;


            }


            return null;

        }





        public HttpResponseMessage getStatementsResponse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_config.GetValue<string>("ClientConnection:accountApiCon"));
                
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"api/AccountManagement/getAccountStatement?AccountId={id}";
                HttpResponseMessage response = client.GetAsync(url).Result;

               
                return response;
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }


        public List<Statement> GetStatementsWithDate(StatementSearch search)
        {



            Statement statement = new Statement();

            HttpResponseMessage response = getStatementsWithDateResponse(search);

            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;

                var list = JsonConvert.DeserializeObject<List<Statement>>(result1);


                return list;


            }


            return null;

        }





        public HttpResponseMessage getStatementsWithDateResponse(StatementSearch search)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_config.GetValue<string>("ClientConnection:accountApiCon"));
                
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"api/AccountManagement/getAccountStatement?AccountId=1&FromDate={search.FromDate}&ToDate={search.ToDate}";
                HttpResponseMessage response = client.GetAsync(url).Result;

                return response;
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }
    }
}
