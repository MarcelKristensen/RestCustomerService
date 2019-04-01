using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            Task<IList<Customer>> t = GetCustomersAsync();
            foreach (var item in t.Result)
            {
                Console.WriteLine($"test: {item.FirstName}");
            }



            Console.ReadKey();


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static string CustomersUri = "https://localhost:44316/api/Customer";
        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }
    }
}
