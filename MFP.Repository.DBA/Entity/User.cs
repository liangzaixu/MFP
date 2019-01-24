using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Repository.Entities.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // ��ע�⣬authenticationType ������ CookieAuthenticationOptions.AuthenticationType �ж������Ӧ��ƥ��
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // �ڴ˴�����Զ����û�����
            return userIdentity;
        }

        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string UserID { get; set; }


        [Required]
        public int Age { get; set; }
    }
}
