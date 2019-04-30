using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer.Model
{
    public class GroupViewModel
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

        /// <summary>
        /// 群主id
        /// </summary>
        public string ownerid { get; set; }

        /// <summary>
        /// 群创建时间
        /// </summary>
        public string createtime { get; set; }
    }
}
