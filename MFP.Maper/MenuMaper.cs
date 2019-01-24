using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Model.BGSystem;
using MFP.Repository.Entities.Entity;


namespace MFP.Maper
{
    public static class MenuMaper
    {

        #region HeaderMenu
        public static HeaderMenuViewModel ToDto(this HeaderMenu source)
        {
            return new HeaderMenuViewModel()
            {
                MenuID = source.MenuID,
                MenuName=source.MenuName,
                Url=source.Url,
                IconUrl=source.IconUrl,
                MenuOrder=source.MenuOrder
            };
        }

        public static HeaderMenu ToEntity(this HeaderMenuViewModel source)
        {
            return new HeaderMenu()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl,
                MenuOrder = source.MenuOrder
            };
        }

        public static List<HeaderMenuViewModel> ToDto(this List<HeaderMenu> source)
        {
            List<HeaderMenuViewModel> target = new List<HeaderMenuViewModel>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }

        public static List<HeaderMenu> ToEntity(this List<HeaderMenuViewModel> source)
        {
            List<HeaderMenu> target = new List<HeaderMenu>();

            foreach (var item in source)
            {
                target.Add(item.ToEntity());
            }
            return target;
        }

        public static HeaderMenuViewModel ToDto(this V_HeaderMenu source)
        {
            return new HeaderMenuViewModel()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl
            };

        }

        public static List<HeaderMenuViewModel> ToDto(this List<V_HeaderMenu> source)
        {
            List<HeaderMenuViewModel> target = new List<HeaderMenuViewModel>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }
        #endregion

        #region SideMenu
        public static SideMenuViewModel ToDto(this SideMenu source)
        {
            return new SideMenuViewModel()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl,
                HeaderMenuID = source.HeaderMenuID,
                ParentID = source.ParentID,
                MenuOrder = source.MenuOrder
            };
        }

        public static SideMenu ToEntity(this SideMenuViewModel source)
        {
            return new SideMenu()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl,
                HeaderMenuID = source.HeaderMenuID,
                ParentID = source.ParentID,
                MenuOrder = source.MenuOrder
            };
        }

        public static List<SideMenuViewModel> ToDto(this List<SideMenu> source)
        {
            List<SideMenuViewModel> target = new List<SideMenuViewModel>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }

        public static List<SideMenu> ToEntity(this List<SideMenuViewModel> source)
        {
            List<SideMenu> target = new List<SideMenu>();

            foreach (var item in source)
            {
                target.Add(item.ToEntity());
            }
            return target;
        }

        public static SideMenuViewModel ToDto(this V_SideMenu source)
        {
            return new SideMenuViewModel()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl,
                HeaderMenuID=source.HeaderMenuID,
                MenuOrder=source.MenuOrder,
                ParentID=source.ParentID
            };

        }

        public static List<SideMenuViewModel> ToDto(this List<V_SideMenu> source)
        {
            List<SideMenuViewModel> target = new List<SideMenuViewModel>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }
        #endregion

    }
}
