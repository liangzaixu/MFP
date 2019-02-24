using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MFP.Repository.Entities.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Service.Identity
{
    public class UserStoreEx<TUser> : UserStore<TUser>, IUserStoreEx where TUser : IdentityUser
    {
        public DbSet<User> UserEntitySet { get; private set; }

        public UserStoreEx(DbContext context)
        {
             context.Set<User>();
        }

        public Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {

           return  UserEntitySet.FirstOrDefaultAsync(u => u.UserId == phoneNumber);
        }
    }
}
