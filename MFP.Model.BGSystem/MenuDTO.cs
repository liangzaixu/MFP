using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Model.BGSystem
{
    public class MenuDTO
    {
        public IList<HeaderMenuDTO> HeaderMenus { get; set; }

        public IList<SideMenuDTO> SideMenus { get; set; }
    }
}
