using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Repository.Entities.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Repository.Entities
{
    public class UserRepository<T> : UserStore<T, Role, string, UserLogin, UserRole, UserClaim>, IUserStore<T> where T: User
    {
        private readonly DbContextBase _context;
        private readonly DbSet<T> _uEntity;

        public UserRepository()
            : this((DbContextBase)DbContextFactory.GetDbContext())
        {
            this.DisposeContext = true;
        }

        public UserRepository(DbContextBase context) : base(context)
        {
            _context = context;
            _uEntity = context.Set<T>();
        }

        public Task<T> FindByPhoneNumberAsync(string phoneNumber)
        {
            return _uEntity.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public Task<T> FindByAccountIDAsync(string accountId)
        {
            return _uEntity.FirstOrDefaultAsync(u => u.AccountId == accountId);
        }

        public T FindByKey(string key)
        {
            return _uEntity.Find(key);
        }
    }


    public class UserRepository:UserStore<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        private DbContextBase _entities = new DbContextBase();

        public UserRepository()
            : this((DbContextBase)DbContextFactory.GetDbContext())
        {
            this.DisposeContext = true;
        }

        public UserRepository(DbContextBase context) : base(context)
        {
            
        }

        public List<User> GetAllUser()
        {
            return _entities.Users.ToList(); 
        }

        public List<User> GetUserToPage(int pageSize = 10, int pageIndex = 0, string keyWord = "")
        {
            IQueryable<User> userQuery= _entities.Users.OrderBy(p=>p.AccountId);
            if (keyWord != "")
            {
                userQuery = userQuery.Where(p => p.AccountId.Contains(keyWord) || p.UserName.Contains(keyWord));
            }
            return userQuery.Skip(pageIndex*pageSize).Take(pageSize).ToList();
        }

        public bool InsertUser(User user)
        {
            _entities.Users.Add(user);
            return _entities.SaveChanges()>0;
        }

        //public bool UpdateUser(UserViewModel user,List<string> proNames)
        //{
        //    User entity =_entities.Users.Find(user.UserID);

        //    if (entity != null)
        //    {
        //        entity.UserName = user.Name;
        //        entity.Age = user.Age;
        //        entity.Email = user.Email;
        //        //entity.Pwd = user.Password;
        //    }

        //    return _entities.SaveChanges()>0;
        //}

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
            return _entities.Users.FirstOrDefault(p => p.AccountId == userID);
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

        public Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            return _entities.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public Task<User> FindByAccountIDAsync(string accountID)
        {
            return _entities.Users.FirstOrDefaultAsync(u => u.AccountId == accountID);
        }
    }
}
