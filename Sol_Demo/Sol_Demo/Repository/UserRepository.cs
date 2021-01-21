using Sol_Demo.Cores;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IEventAggregator eventAggregator = null;

        public UserRepository(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        Task<bool> IUserRepository.AddUserAsync(UserModel userModel)
        {
            return Task.Run(() =>
            {
                // Save Data To Database.

                // Publish Event for Mail Notification (Fire and Forgot)
                Task.Factory.StartNew(() =>
                {
                    this.eventAggregator.Publish<UserModel>("MailNotification", userModel);
                }, TaskCreationOptions.RunContinuationsAsynchronously);

                return true;
            });
        }
    }
}