using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AnkundaWebsite2
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager)
        {            
            SeedUser(userManager);
        }

        private static void SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    PhoneNumber = "82355564"
                };
                var result = userManager.CreateAsync(user, "Password1#").Result;
                if (result.Succeeded)
                {
                    
                }

            }
        }

         
    }
}
