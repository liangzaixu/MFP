using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.DBA.Entity;
using MFP.Model.BGSystem;

namespace MFP.Repository.DBA
{
    public class UserRepository
    {
        private DbContextBase _entities = new DbContextBase();

        public List<User> GetAllUser()
        {
            return _entities.Users.ToList(); 
        }

        public List<User> GetUserToPage(int pageSize = 10, int pageIndex = 0, string keyWord = "")
        {
            IQueryable<User> userQuery= _entities.Users.OrderBy(p=>p.UserID);
            if (keyWord != "")
            {
                userQuery = userQuery.Where(p => p.UserID.Contains(keyWord) || p.Name.Contains(keyWord));
            }
            return userQuery.Skip(pageIndex*pageSize).Take(pageSize).ToList();
        }

        public bool InsertUser(User user)
        {
            _entities.Users.Add(user);
            return _entities.SaveChanges()>0;
        }

        public bool UpdateUser(UserDTO user,List<string> proNames)
        {
            User entity =_entities.Users.Find(user.UserID);

            if (entity != null)
            {
                entity.Name = user.Name;
                entity.Age = user.Age;
                entity.Email = user.Email;
                entity.Pwd = user.Password;
            }

            return _entities.SaveChanges()>0;
        }

        public bool DeleteUser(string userID)
        {
            User entity= _entities.Users.Find(userID);
            if (entity == null)
            {
                return false;
            }
            _entities.Users.Remove(entity);
            return _entities.SaveChanges() > 0;
        }

        public User GetDetail(string userID)
        {
            return _entities.Users.FirstOrDefault(p => p.UserID == userID);
        }

        public void JustForTest()
        {
            _entities.Persons.Add(new Person()
            {
                Name = "靓仔A",
            });

            _entities.SaveChanges();

            Person person1= _entities.Persons.FirstOrDefault();

            using (var context = new DbContextBase())
            {
                Person person2= context.Persons.FirstOrDefault();
                person2.Name = "靓仔C";
                context.SaveChanges();
            }

            person1.Name = "靓仔B";

            try
            {
                _entities.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
        }

        public void JustForTest2()
        {
            var context1 = new DbContextBase();
            var context2 = new DbContextBase();

            using (var trans = context2.Database.BeginTransaction())
            {

            }
        }
    }
}
