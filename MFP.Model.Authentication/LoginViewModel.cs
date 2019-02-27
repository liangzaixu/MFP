using MFP.Model.Identity.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Model.Identity
{
    public class LoginViewModel
    {
        /// <summary>
        /// 账号可以是UserId\PhoneNumber\Email
        /// </summary>
        [Display(Name = "账号")]
        [RegularExpression(@"^[a-zA-Z0-9.-_@]{3,20}|^[0-9]{11}$|^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$", ErrorMessage = "可以使用账号/手机号码/邮箱登录")]
        public string AccountId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}
