using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MFP.Repository.Entities;
using MFP.Repository.Entities.Entity;


namespace MFP.Service.BGSystem
{
    public class DemoService
    {
        private BaseRepository<User> userRepositroy = new BaseRepository<User>();
        private BaseRepository<Log> logRepositroy = new BaseRepository<Log>();
        private BaseRepository<V_SideMenu> menuRepositroy = new BaseRepository<V_SideMenu>();

        public DemoService()
        {

        }

        public void DoSomething()
        {
            try
            {
                DbSession.BeginTransaction();
                string userID = Guid.NewGuid().ToString();
                userRepositroy.Insert(new User() {AccountId = userID, UserName = "雄介", Age = 18, Email = "123", PasswordHash = "123"});
                logRepositroy.Insert(new Log() {UserID = userID, IP = "127.0.0.1", OperateTime = DateTime.Now});
                DbSession.CommitTransaction();
            }
            catch
            {

            }
        }

        public void TestAsNoTracking()
        {
            List<V_SideMenu> sideMenu= menuRepositroy.Entities.Where(m => m.UserID == "admin").ToList();
        }
    }
}