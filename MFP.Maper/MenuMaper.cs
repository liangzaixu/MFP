using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFP.Model.BGSystem;
using MFP.Repository.DBA.Entity;


namespace MFP.Maper
{
    public static class MenuMaper
    {

        #region HeaderMenu
        public static HeaderMenuDTO ToDto(this HeaderMenu source)
        {
            return new HeaderMenuDTO()
            {
                MenuID = source.MenuID,
                MenuName=source.MenuName,
                Url=source.Url,
                IconUrl=source.IconUrl,
                MenuOrder=source.MenuOrder
            };
        }

        public static HeaderMenu ToEntity(this HeaderMenuDTO source)
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

        public static List<HeaderMenuDTO> ToDto(this List<HeaderMenu> source)
        {
            List<HeaderMenuDTO> target = new List<HeaderMenuDTO>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }

        public static List<HeaderMenu> ToEntity(this List<HeaderMenuDTO> source)
        {
            List<HeaderMenu> target = new List<HeaderMenu>();

            foreach (var item in source)
            {
                target.Add(item.ToEntity());
            }
            return target;
        }

        public static HeaderMenuDTO ToDto(this V_HeaderMenu source)
        {
            return new HeaderMenuDTO()
            {
                MenuID = source.MenuID,
                MenuName = source.MenuName,
                Url = source.Url,
                IconUrl = source.IconUrl
            };

        }

        public static List<HeaderMenuDTO> ToDto(this List<V_HeaderMenu> source)
        {
            List<HeaderMenuDTO> target = new List<HeaderMenuDTO>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }
        #endregion

        #region SideMenu
        public static SideMenuDTO ToDto(this SideMenu source)
        {
            return new SideMenuDTO()
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

        public static SideMenu ToEntity(this SideMenuDTO source)
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

        public static List<SideMenuDTO> ToDto(this List<SideMenu> source)
        {
            List<SideMenuDTO> target = new List<SideMenuDTO>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }

        public static List<SideMenu> ToEntity(this List<SideMenuDTO> source)
        {
            List<SideMenu> target = new List<SideMenu>();

            foreach (var item in source)
            {
                target.Add(item.ToEntity());
            }
            return target;
        }

        public static SideMenuDTO ToDto(this V_SideMenu source)
        {
            return new SideMenuDTO()
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

        public static List<SideMenuDTO> ToDto(this List<V_SideMenu> source)
        {
            List<SideMenuDTO> target = new List<SideMenuDTO>();

            foreach (var item in source)
            {
                target.Add(item.ToDto());
            }
            return target;
        }
        #endregion

    }
}
