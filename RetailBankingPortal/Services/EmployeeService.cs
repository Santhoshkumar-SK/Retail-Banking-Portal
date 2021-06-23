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
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _config;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> loginEmployee(UserDTO user)
        {

            string token = null;
            HttpResponseMessage result = loginEmployeeResponse(user);

            if (result.IsSuccessStatusCode)
            {
                var apiResponse = await result.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<string>(apiResponse);


            }

            return token;
        }


        public HttpResponseMessage loginEmployeeResponse(UserDTO user)
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

        public Customer getCustomerDetails(int id)
        {



            Customer customer = new Customer();

            HttpResponseMessage response = getCustomerResponse(id);

            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result1);
                return customer;
            }
            
            return null;



        }


        
        public HttpResponseMessage getCustomerResponse(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_config.GetValue<string>("ClientConnection:customerApiCon"));
                var token = _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string url = $"api/Customer/getCustomerDetails?Customer_Id={id}";
                HttpResponseMessage response = client.GetAsync(url).Result;

                return response;
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }


        public async Task<CreateCustomerResponse> createCustomer(CreateCustomer createCustomer)
        {

            CreateCustomerResponse response = null;
            HttpResponseMessage result = createCustomerResponse(createCustomer);

            if (result.IsSuccessStatusCode)
            {
                var apiResponse = await result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<CreateCustomerResponse>(apiResponse);
                return response;
            }

            return null;
        }


        

        public HttpResponseMessage createCustomerResponse(CreateCustomer createCustomer)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            string uriConn = _config.GetValue<string>("ClientConnection:customerApiCon");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn + "api/Customer/createCustomer");

                client.DefaultRequestHeaders.Clear();

                var token = _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync<CreateCustomer>(client.BaseAddress, createCustomer);

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

    }
}
