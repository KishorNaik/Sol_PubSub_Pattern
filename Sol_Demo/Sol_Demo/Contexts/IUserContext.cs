using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts
{
    public interface IUserContext
    {
        Task<bool> AddUserAsync(UserModel userModel);
    }
}