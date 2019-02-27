using MFP.Repository.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.Entities
{
    interface IUserStoreEx<TUser>
    {
        Task<TUser> FindByPhoneNumberAsync(string phoneNumber);
    }
}
