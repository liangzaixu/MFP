using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.DBA.Entity;
using MFP.Model.BGSystem;

namespace MFP.Maper
{
    public static class UserMaper
    {
        public static User ToEntity(this UserDTO source)
        {
            if (source.PasswordE != null)
            {
                source.Password = source.PasswordE;
            }
            return new User()
            {
                UserID = source.UserID,
                Name = source.Name,
                Age = source.Age,
                Email = source.Email,
                Pwd = source.Password
            };
        }

        public static UserDTO ToDto(this User source)
        {
            return new UserDTO()
            {
                UserID = source.UserID,
                Name = source.Name,
                Age = source.Age,
                Email = source.Email,
            };
        }

        public static List<User> ToEntity(this List<UserDTO> source)
        {
            List<User> result = new List<User>();

            foreach (var item in source)
            {
                result.Add(item.ToEntity());
            }

            return result;
        }

        public static List<UserDTO> ToDto(this List<User> source)
        {
            List<UserDTO> result = new List<UserDTO>();

            foreach (var item in source)
            {
                result.Add(item.ToDto());
            }

            return result;
        }
    }
}
