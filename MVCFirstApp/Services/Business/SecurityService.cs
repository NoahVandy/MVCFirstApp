using MVCFirstApp.Models;
using MVCFirstApp.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFirstApp.Services.Business
{
    public class SecurityService
    {
        SecurityDAO service = new SecurityDAO();
        public bool Authenticate(UserModel user)
        {
            
            return service.FindByUser(user);
        }
    }
}