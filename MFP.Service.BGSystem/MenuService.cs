using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Model.BGSystem;
using MFP.Repository.DBA;
using MFP.Repository.DBA.Entity;
using MFP.Maper;

namespace MFP.Service.BGSystem
{
    public class MenuService
    {
        private BaseRepository<V_HeaderMenu> _headerMenuRep;
        private BaseRepository<V_SideMenu> sideMenuRep;

        public MenuService()
        {
            _headerMenuRep = new BaseRepository<V_HeaderMenu>();
            sideMenuRep = new BaseRepository<V_SideMenu>();
        }

        public MenuDTO GetMenus(string userID)
        {
            List<V_HeaderMenu> headerMenus = _headerMenuRep.Entities.Where(u => u.UserID == userID).OrderBy(u => u.MenuOrder).ToList();
            List<V_SideMenu> sideMenus = sideMenuRep.Entities.Where(u => u.UserID == userID).OrderBy(u => u.MenuOrder).ToList();

            List<SideMenuDTO> sideMenuDtos = new List<SideMenuDTO>();
            List<V_SideMenu> sideMenuRoot = sideMenus.Where(m => m.ParentID == "root").ToList();

            foreach (var item in sideMenuRoot)
            {
                SideMenuDTO temp= item.ToDto();
                temp.Children = GetChildren(sideMenus, temp.MenuID, item.HasChildren==1);
                sideMenuDtos.Add(temp);
            }

            return new MenuDTO
            {
                HeaderMenus= headerMenus.ToDto(),
                SideMenus= sideMenuDtos
            };
        }

        private IList<SideMenuDTO> GetChildren(List<V_SideMenu> source, string parentID, bool hasChildren)
        {
            if (!hasChildren)
            {
                return null;
            }

            IList<SideMenuDTO> target = source.Where(m => m.ParentID == parentID).OrderBy(m => m.MenuOrder).Select(m => new SideMenuDTO()
            {
                MenuID = m.MenuID,
                MenuName = m.MenuName,
                MenuOrder = m.MenuOrder,
                HeaderMenuID = m.HeaderMenuID,
                IconUrl = m.IconUrl,
                ParentID = m.ParentID,
                Url = m.Url,
                Children = GetChildren(source, m.MenuID, m.HasChildren==1)
            }).ToList();

            return target;
        }

    }
}
