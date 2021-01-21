using Sol_Demo.Cores;
using Sol_Demo.Models;
using Sol_Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts
{
    public sealed class UserContext : IUserContext
    {
        private readonly IEventAggregator eventAggregator = null;
        private readonly IUserRepository userRepository = null;

        public UserContext(IEventAggregator eventAggregator, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.Subscribe<UserModel>("MailNotification", OnMailNotification);

            //Using Lambda Expression
            //this.eventAggregator.Subscribe<UserModel>("MailNotification", (userModel) =>
            //{
            //    Console.WriteLine(userModel.EmailId);
            //    Console.WriteLine("Mail Send");
            //});
        }

        Task<bool> IUserContext.AddUserAsync(UserModel userModel)
        {
            return this.userRepository.AddUserAsync(userModel);
        }

        //Event Handler
        private void OnMailNotification(UserModel userModel)
        {
            Console.WriteLine(userModel.EmailId);
            Console.WriteLine("Mail Send");

            eventAggregator.UnSubscribe("MailNotification");
        }
    }
}