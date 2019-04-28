using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MFP.ChatServer.Model;
using MFP.Repository.Entities;
using MFP.Repository.Entities.Entity;

namespace MFP.ChatServer
{
    public class ChatService
    {
        private BaseRepository<Chat_FriendGroup> _friendGroupRep;
        private BaseRepository<Chat_Group> _groupRep;
        private ChatRepository _chatRep;

        public ChatService()
        {
            this._friendGroupRep = new BaseRepository<Chat_FriendGroup>();
            this._groupRep = new BaseRepository<Chat_Group>();
            this._chatRep = new ChatRepository();
        }

        public ChatService(BaseRepository<Chat_FriendGroup> friendGroupRep, BaseRepository<Chat_Group> groupRep, ChatRepository chatRep)
        {
            this._friendGroupRep = friendGroupRep;
            this._groupRep = groupRep;
            this._chatRep = chatRep;
        }

        public InitResult GetInitData(string userId)
        {

            List<FriendGroup> friendGroups_vm = new List<FriendGroup>();
            List<Chat_FriendGroup> friendGroups_e = _friendGroupRep.Entities.Where(m => m.OwnerId == userId).OrderBy(m => m.OrderNo).ToList();
            List<Model.User> friends_vm = _chatRep.GetFriends(userId);

            foreach(var groupItem in friendGroups_vm)
            {
                foreach(var userItem in friends)
                {
                    if(userItem.groupid==groupItem.Id)
                    {
                        groupItem.list.Add(userItem.to)
                    }
                }
            }


            return null;
        }
    }
}
