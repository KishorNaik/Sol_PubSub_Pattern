using Sol_Demo.Contexts;
using Sol_Demo.Cores;
using Sol_Demo.Models;
using Sol_Demo.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IEventAggregator eventAggregator = new EventAggregator();

            UserModel userModel = new()
            {
                FirstName = "Kishor",
                LastName = "Naik",
                EmailId = "kishor@gmail.com"
            };

            IUserRepository userRepository = new UserRepository(eventAggregator);
            IUserContext userContext = new UserContext(eventAggregator, userRepository);

            bool flag = await userContext.AddUserAsync(userModel);
            Console.WriteLine((flag == true) ? "Save" : "something went wrong");
        }
    }
}