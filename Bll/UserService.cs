using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dal;
using Dal.Entities;
using System.Web;

namespace Bll
{
    public class UserService
    {
        private UserRepository _userRepositroy = new UserRepository();
        public List<UserDTO> GetAllUser()
        {
            var users=_userRepositroy.GetAllUser();
            var usersViewModel = new List<UserDTO>();
            foreach (var item in users)
            {
                usersViewModel.Add(new UserDTO()
                {
                    UserID = item.UserID,
                    Name = item.Name,
                    Age = Convert.ToInt32(item.Age) ,
                    Email = item.Email
                });
            }
            return usersViewModel;
        }

        public List<UserDTO> GetUserToPage(int pageSize=10,int pageIndex=0, string keyWord="")
        {
            List<User> listDBModel= _userRepositroy.GetUserToPage(pageSize, pageIndex, keyWord);
            List<UserDTO> listViewModel = new List<UserDTO>();
            foreach (User item in listDBModel)
            {
                listViewModel.Add(new UserDTO
                {
                     UserID= item.UserID,
                     Name=item.Name,
                     Age=Convert.ToInt32(item.Age),
                     Email=item.Email
                });
            }
            return listViewModel;
        }

        public bool AddUser(UserDTO user)
        {
            return _userRepositroy.InsertUser(new User()
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Pwd = user.Password
            });
        }

        public bool EditUser(UserDTO user)
        {
            return _userRepositroy.UpdateUser(user, null);
        }

        public bool DeleteUser(string userID)
        {
            return _userRepositroy.DeleteUser(userID);
        }

        public UserDTO GetUserDetail(string userID)
        {
            User userDbModel = _userRepositroy.GetDetail(userID);
            UserDTO userViewModel = new UserDTO()
            {
                UserID = userDbModel.UserID,
                Name = userDbModel.Name,
                Age = Convert.ToInt32(userDbModel.Age),
                Email = userDbModel.Email
            };
            return userViewModel;
        }

        public void JustForTest()
        {
            _userRepositroy.JustForTest();
        }

        public bool AtAsyncHttpContextCurrentIsNull()
        {
            if (HttpContext.Current == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
