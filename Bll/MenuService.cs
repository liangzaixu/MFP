using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Models;

namespace Bll
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
