using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class Group
    {
        /// <summary>
        /// 群组名
        /// </summary>
        public string groupname { get; set; }

        /// <summary>
        /// 群组ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 群组头像
        /// </summary>
        public string avatar { get; set; }
    }
}
