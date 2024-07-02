using Cores.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ahmed",
                    Email = "Ahmed@gmail.com",
                    UserName= "Ahmed@gmail.com",
                    address=new Address
                    {
                        FirstName="Ahmed",
                        LastName="Wael",
                        City="Tanta",
                        Street="El Mahlla",
                        Status="T",
                        zIPCode="13535"


                    }
                };
                await userManager.CreateAsync(user,"Ahmed123456?");
            }
            

            
        }
    }
}
