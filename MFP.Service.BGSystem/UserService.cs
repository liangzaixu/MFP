using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MFP.Model.BGSystem;
using MFP.Repository.DBA;
using MFP.Repository.DBA.Entity;
using MFP.Maper;
using MFP.CommonModel;

namespace MFP.Service.BGSystem
{
    public class UserService
    {
        private BaseRepository<User> _userRepositroy;

        public UserService()
        {
            _userRepositroy = new BaseRepository<User>();
        }

        public PageResult<List<UserDTO>> GetUserToPage(int pageIndex=0, int pageSize = 10, string keyWord="")
        {
            IQueryable<User> userQuery = _userRepositroy.Entities.OrderBy(p => p.UserID);
            if (keyWord != "")
            {
                userQuery = userQuery.Where(p => p.UserID.Contains(keyWord) || p.Name.Contains(keyWord));
            }

            int total = userQuery.Count();

            List<User> userEntities=userQuery.Skip((pageIndex-1) * pageSize).Take(pageSize).ToList();

            return new PageResult<List<UserDTO>>()
            {
                Status=200,
                Msg="",
                Total = total,
                Data= userEntities.ToDto()
            };
        }

        public bool AddUser(UserDTO user)
        {
            return _userRepositroy.Insert(new User()
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
            return _userRepositroy.Update(user.ToEntity(), null);
        }

        public bool DeleteUser(string userID)
        {
            return _userRepositroy.Delete(userID);
        }

        public UserDTO GetUserDetail(string userID)
        {
            User userDbModel = _userRepositroy.Entities.FirstOrDefault(m=>m.UserID==userID);
            return userDbModel.ToDto();
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
