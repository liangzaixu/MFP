using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Model.BGSystem
{
    public class HeaderMenuViewModel
    {
        private string _url;

        public HeaderMenuViewModel()
        {
            SideMenus = new List<SideMenuViewModel>();
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

        public List<SideMenuViewModel> SideMenus { get; set; }
    }
}
