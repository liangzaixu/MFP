using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MFP.Repository.Entities;
using MFP.Repository.Entities.Entity;
using MFP.Model.Identity;

namespace MFP.Service.Identity
{

    public class UserService : UserManager<User>
    {
        public UserService(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            var manager = new UserService(new UserRepository<User>(context.Get<DbContextBase>()));
            // 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // 配置密码的验证逻辑
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // 配置用户锁定默认值
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            // 你可以编写自己的提供程序并将其插入到此处。
            manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "你的安全代码是 {0}"
            });
            manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<User>
            {
                Subject = "安全代码",
                BodyFormat = "你的安全代码是 {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public async Task<IdentityResult> CreateAsync(RegisterViewModel model)
        {
            User user = new User()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Email = model.Email,
            };
            IdentityResult identityResult = await this.CreateAsync(user, model.Password);
            return identityResult;
        }

        /// <summary>
        ///     Find a user by phone number
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentNullException("userName");
            }

            var cast = Store as IUserStoreEx;

            if (cast == null)
            {
                throw new ArgumentNullException("cast");
            }

            return cast.FindByPhoneNumberAsync(phoneNumber);
        }

       


    }
}
