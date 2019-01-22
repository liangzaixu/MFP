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

        public List<HeaderMenuViewModel> GetMenus(string userID)
        {
            List<V_HeaderMenu> headerMenus = _headerMenuRep.Entities.Where(u => u.UserID == userID).OrderBy(u => u.MenuOrder).ToList();
            List<V_SideMenu> sideMenus = sideMenuRep.Entities.Where(u => u.UserID == userID).OrderBy(u => u.MenuOrder).ToList();

            List<HeaderMenuViewModel> headerMenuDtos = headerMenus.ToDto();

            List<SideMenuViewModel> sideMenuDtos = new List<SideMenuViewModel>();
            List<V_SideMenu> sideMenuRoot = sideMenus.Where(m => m.ParentID == "root").ToList();

            foreach (var item in sideMenuRoot)
            {
                SideMenuViewModel temp= item.ToDto();
                temp.Children = GetChildren(sideMenus, temp.MenuID, item.HasChildren==1);


                //右侧菜单的HeaderMenuID等于root时，说明头部不存在菜单。那么就在程序层add一个root的头部菜单节点。
                //不显示顶部root节点，仅显示顶部root节点下的右侧菜单
                if (temp.HeaderMenuID == "root")
                {
                    if (headerMenuDtos.Count == 0)
                    {
                        headerMenuDtos.Add(new HeaderMenuViewModel()
                        {
                            MenuID = "root"
                        });
                    }

                    headerMenuDtos[0].SideMenus.Add(temp);
                }
                else
                {
                    headerMenuDtos.FirstOrDefault(m => m.MenuID == temp.HeaderMenuID).SideMenus.Add(temp);
                }
            }

            return headerMenuDtos;

        }

        private IList<SideMenuViewModel> GetChildren(List<V_SideMenu> source, string parentID, bool hasChildren)
        {
            if (!hasChildren)
            {
                return null;
            }

            IList<SideMenuViewModel> target = source.Where(m => m.ParentID == parentID).OrderBy(m => m.MenuOrder).Select(m => new SideMenuViewModel()
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
