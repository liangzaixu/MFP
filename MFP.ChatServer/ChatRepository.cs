using System;
using System.Collections.Generic;
using System.Text;
using MFP.Repository.Entities;
using MFP.Repository.Entities.Entity;
using System.Linq;
using MFP.ChatServer.Model;

namespace MFP.ChatServer
{
    public class ChatRepository
    {
        public DbContextBase DbContext { get; private set; }

        public ChatRepository()
        {
            DbContext = DbContextFactory.GetDbContext();
        }

        public List<UserViewModel> GetFriends(string userId)
        {
            var users = (from fgu in DbContext.Chat_FriendGroupUser
                         join u in DbContext.Users
                        on fgu.UserId equals u.AccountId
                         join fg in DbContext.Chat_FriendGroup
                         on fgu.FriendGroupId equals fg.Id
                         orderby fg.OrderNo, u.UserName
                         where u.AccountId == userId
                         select new UserViewModel()
                         {
                             id = u.AccountId,
                             username = u.UserName,
                             groupid = fg.Id.ToString(),
                             avatar=u.Photo,
                             sign=u.Sign

                         }).ToList();
            return users;
        }
    }
}
