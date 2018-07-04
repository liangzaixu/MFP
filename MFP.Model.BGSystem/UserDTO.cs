using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MFP.Model.BGSystem
{
    public class UserDTO
    {
        [Required(ErrorMessage ="这是必填项")]
        [MaxLength(20, ErrorMessage = "ID长度要求1-20个字符")]
        public string UserID { get; set; }

        [Required(ErrorMessage ="这是必填项")]
        [MaxLength(50,ErrorMessage="姓名长度要求1-50个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage ="这是必填项")]
        public int Age { get; set; }

        [Required(ErrorMessage = "这是必填项")]
        public string Email { get; set; }

        [Required(ErrorMessage = "这是必填项")]
        [RegularExpression(@"^([0-9a-zA-Z`~\!@#$%\^&*\(\)_\+-={}|\[\]:;\'<>\?,.\/\\]){6,20}$",ErrorMessage ="密码格式错误")]
        public string Password { get; set; }
    }
}
