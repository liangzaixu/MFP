using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Model.BGSystem
{
    public class HeaderMenuDTO
    {
        private string _url;

        public HeaderMenuDTO()
        {
            SideMenus = new List<SideMenuDTO>();
        }

        public string MenuID { get; set; }

        public string MenuName { get; set; }

        public string Url
        {
            get { return string.IsNullOrEmpty(_url) ? "javascript:void(0);" : _url; }
            set { _url = value; }
        }

        public string IconUrl { get; set; }

        public int MenuOrder { get; set; }

        public List<SideMenuDTO> SideMenus { get; set; }
    }
}
