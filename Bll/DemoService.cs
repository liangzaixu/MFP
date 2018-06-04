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
    public class DemoService
    {
        private BaseRepository<User> userRepositroy = new BaseRepository<User>();
        private BaseRepository<Log> logRepositroy = new BaseRepository<Log>();

        public DemoService()
        {

        }

        public void DoSomething()
        {
            try
            {
                DbSession.BeginTransaction();
                string userID = Guid.NewGuid().ToString();
                userRepositroy.Insert(new User() {UserID = userID, Name = "雄介", Age = 18, Email = "123", Pwd = "123"});
                logRepositroy.Insert(new Log() {UserID = userID, IP = "127.0.0.1", OperateTime = DateTime.Now});
                DbSession.CommitTransaction();
            }
            catch
            {

            }
        }

        public void TestAsNoTracking()
        {
            
        }
    }
}