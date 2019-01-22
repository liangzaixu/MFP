using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Model.BGSystem
{
    public class MenuViewModel
    {
        public IList<HeaderMenuViewModel> HeaderMenus { get; set; }

        public IList<SideMenuViewModel> SideMenus { get; set; }
    }
}
