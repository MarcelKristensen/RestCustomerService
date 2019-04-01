using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using RestCustomerService.Model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "Marcel", "Kristensen", 1996),
            new Customer(2, "Lasse", "Henriksen", 1633),
            new Customer(3, "Sofus", "Nielsen", 2015),
            new Customer(4, "Jacob", "ikke-taber", 1)
                
        };
        

        // GET: api/Customer
        [HttpGet]
        public List<Customer> Get()  // or public IEnumerable<string> Get()
        {
            return cList;
        }


        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer CustomerGet(int id)
        {          
            var item = cList.SingleOrDefault(c => c.ID == id);
            return item;
        }

        // POST: api/Customer
        [HttpPost]
        public Customer CustomerInsert(Customer c) //[FromBody] string value som andet parameter
        {
            if (!cList.Contains(c))
            {
                cList.Add(c);
                return c;
            }

            return null;
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, [FromBody] Customer newCustomer)
        {
            if (cList.Exists(x => x.ID == id))
            {
                int indexOfOldCustomer = cList.FindIndex(x => x.ID == id);
                cList[indexOfOldCustomer] = newCustomer;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var item = cList.SingleOrDefault(c => c.ID == id);
            cList.Remove(item);
        }
    }
}
