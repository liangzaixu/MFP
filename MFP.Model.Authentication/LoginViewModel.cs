﻿using MFP.Model.Identity.Properties;
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

        [Display(Name = "账号")]
        [EmailAddress]
        [RegularExpression(@"^[0-9]{1,20}$",ErrorMessage = "请输入0-9的数字")]
        public string AccountId
        {
            get;
            set;
        }

        [Display(Name = "电子邮件")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}
