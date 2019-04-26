using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class Mine
    {
        /// <summary>
        /// 我的昵称
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 我的ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 在线状态 online：在线、hide：隐身
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 我的签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 我的头像
        /// </summary>
        public string avatar { get; set; }
    }
}
