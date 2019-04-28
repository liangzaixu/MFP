using MFP.Repository.Entities.Entity;
using MFP.ChatServer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFP.ChatServer
{
    public static class ChatMaper
    {
        public static Chat_FriendGroup ToEntity(this FriendGroup source)
        {
            return new Chat_FriendGroup()
            {
                Id = Convert.ToInt32(source.id),
                Name = source.groupname,
                OwnerId = source.ownerid
            };
        }

        public static FriendGroup ToViewModel(this Chat_FriendGroup source)
        {
            return new FriendGroup()
            {
                id = source.Id.ToString(),
                groupname = source.Name,
                ownerid = source.OwnerId,
            };
        }

        public static User ToViewModel(this Chat_FriendGroup source)
        {
            return new FriendGroup()
            {
                id = source.Id.ToString(),
                groupname = source.Name,
                ownerid = source.OwnerId,
            };
        }

    }
}
