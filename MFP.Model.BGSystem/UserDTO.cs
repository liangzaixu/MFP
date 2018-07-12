using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MFP.Model.BGSystem.Properties;

namespace MFP.Model.BGSystem
{
    public class UserDTO
    {
        [Display(Name = "用户ID")]
        [Required(ErrorMessageResourceName ="UserIDRequired", ErrorMessageResourceType = typeof(Resources))]
        [RegularExpression("^([a-zA-Z0-9]{1,20})$", ErrorMessageResourceName = "UserIDRule", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(20, ErrorMessage = "ID长度要求1-20个字符")]
        [DataType(DataType.Text)]
        public string UserID { get; set; }

        [Display(Name="用户名")]
        [Required(ErrorMessage ="这是必填项")]
        [RegularExpression(@"^[a-zA-Z0-9_\u4e00-\u9fa5][a-zA-Z0-9_\u4e00-\u9fa5 ]{0,48}[a-zA-Z0-9_\u4e00-\u9fa5]$|^[a-zA-Z0-9_\u4e00-\u9fa5]{1,50}$",ErrorMessage = "用户姓名由1-20位的汉字、字母、数字、下划线组成")]
        [MaxLength(50,ErrorMessage="姓名长度要求1-50个字符")]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        [Required(ErrorMessage ="这是必填项")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$",ErrorMessage ="邮箱格式错误")]
        [Required(ErrorMessage = "这是必填项")]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "这是必填项")]
        [RegularExpression(@"^([0-9a-zA-Z`~\!@#$%\^&*\(\)_\+-={}|\[\]:;\'<>\?,.\/\\]){6,20}$",ErrorMessage ="密码格式错误")]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "这是必填项")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([0-9a-zA-Z`~\!@#$%\^&*\(\)_\+-={}|\[\]:;\'<>\?,.\/\\]){6,20}$", ErrorMessage = "密码格式错误")]
        [Compare("Password",ErrorMessage ="两次密码不一致")]
        public string Password2 { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([0-9a-zA-Z`~\!@#$%\^&*\(\)_\+-={}|\[\]:;\'<>\?,.\/\\]){6,20}$|^$", ErrorMessage = "密码格式错误")]
        public string PasswordE { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([0-9a-zA-Z`~\!@#$%\^&*\(\)_\+-={}|\[\]:;\'<>\?,.\/\\]){6,20}$|^$", ErrorMessage = "密码格式错误")]
        [Compare("PasswordE", ErrorMessage = "两次密码不一致")]
        public string PasswordE2 { get; set; }
    }
}
