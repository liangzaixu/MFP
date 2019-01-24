using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.Entities.Entity;
using MFP.Model.BGSystem;

namespace MFP.Maper
{
    public static class UserMaper
    {
        public static User ToEntity(this UserViewModel source)
        {
            if (source.PasswordE != null)
            {
                source.Password = source.PasswordE;
            }
            return new User()
            {
                UserID = source.UserID,
                UserName = source.Name,
                Age = source.Age,
                Email = source.Email,
                PasswordHash = source.Password
            };
        }

        public static UserViewModel ToDto(this User source)
        {
            return new UserViewModel()
            {
                UserID = source.UserID,
                Name = source.UserName,
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

        public static List<UserViewModel> ToDto(this List<User> source)
        {
            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var item in source)
            {
                result.Add(item.ToDto());
            }

            return result;
        }
    }
}
