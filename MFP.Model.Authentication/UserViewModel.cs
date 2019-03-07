using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MFP.Model.Identity.Properties;

namespace MFP.Model.Identity
{
    public class UserViewModel
    {

        public string Id { get; set; }

        public string AccountId { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
