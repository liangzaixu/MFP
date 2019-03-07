using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.Entities.Entity;
using MFP.Model.Identity;

namespace MFP.Maper
{
    public static class UserMaper
    {
        public static User ToEntity(this UserViewModel source)
        {
            return new User()
            {
                Id=source.Id,
                AccountId = source.AccountId,
                UserName = source.UserName,
                Age = source.Age,
                Email = source.Email,
            };
        }

        public static UserViewModel ToViewModel(this User source)
        {
            return new UserViewModel()
            {
                AccountId = source.AccountId,
                UserName = source.UserName,
                Age = source.Age,
                Email = source.Email,
            };
        }

        public static List<User> ToEntity(this List<UserViewModel> source)
        {
            List<User> result = new List<User>();

            foreach (var item in source)
            {
                result.Add(item.ToEntity());
            }

            return result;
        }

        public static List<UserViewModel> ToViewModel(this List<User> source)
        {
            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var item in source)
            {
                result.Add(item.ToViewModel());
            }

            return result;
        }
    }
}
