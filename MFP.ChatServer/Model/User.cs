using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class User
    {
        /// <summary>
        /// 好友昵称
        /// </summary>
        public string user { get; set; }

        /// <summary>
        /// 好友ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 好友头像
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 好友签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 在线状态，若值为offline代表离线，online或者不填为在线
        /// </summary>
        public string status { get; set; }
    }
}
