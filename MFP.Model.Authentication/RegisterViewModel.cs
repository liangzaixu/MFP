using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MFP.Model.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.-_@]{3,20}$")]
        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        [Display(Name = "账号")]
        public string UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.·\u4e00-\u9fa5]{3,20}$")]
        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} 必须至少包含 {5} 个字符。", MinimumLength = 5)]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }


        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }
}
