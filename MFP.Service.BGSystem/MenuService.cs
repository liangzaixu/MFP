using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Model.BGSystem;
using MFP.Repository.DBA;

namespace MFP.Service.BGSystem
{
    public class MenuService
    {
        private BaseRepository<MenuDTO> menuRepository;

        public MenuService()
        {
            
        }

        public List<MenuDTO> GetMenuByUserID()
        {
            return null;
        }

    }
}
