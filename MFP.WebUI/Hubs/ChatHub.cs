using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MFP.WebUI.Hubs
{
    public class ServerHub : Hub
    {
        private static readonly char[] str =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
        };

        /// <summary>
        /// 消息发送接口
        /// </summary>
        /// <param name="message"></param>
        public void SendMsg(string message)
        {
            var name = GenerateUserName(4);

            // 调用所有客户端的sendMessage方法
            Clients.All.sendMessage(name, message);
        }

        /// <summary>
        /// 产生随机用户
        /// </summary>
        /// <param name="length">用户名长度</param>
        /// <returns></returns>
        public static string GenerateUserName(int length)
        {
            var newRandom = new StringBuilder(62);
            var rd = new Random();
            for (var i = 0; i < length; i++)
            {
                newRandom.Append(str[rd.Next(62)]);
            }

            return newRandom.ToString();
        }
    }
}