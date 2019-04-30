using MFP.Repository.Entities.Entity;
using MFP.ChatServer.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace MFP.ChatServer
{
    public static class ChatMaper
    {
        public static Chat_FriendGroup ToEntity(this FriendGroupViewModel source)
        {
            return new Chat_FriendGroup()
            {
                Id = Convert.ToInt32(source.id),
                Name = source.groupname,
                OwnerId = source.ownerid
            };
        }


        public static FriendGroupViewModel ToViewModel(this Chat_FriendGroup source)
        {
            return new FriendGroupViewModel()
            {
                id = source.Id.ToString(),
                groupname = source.Name,
                ownerid = source.OwnerId,
            };
        }

        public static GroupViewModel ToViewModel(this Chat_Group source)
        {
            return new GroupViewModel()
            {
                id=source.Id.ToString(),
                groupname=source.Name,
                avatar=source.Photo
            };
        }

        public static List<GroupViewModel> ToViewModel(this List<Chat_Group> source)
        {
            List<GroupViewModel> result = new List<GroupViewModel>();

            foreach(var item in source)
            {
                result.Add(item.ToViewModel());
            }
            return result;
        }

        public static Chat_Group ToEntity(this GroupViewModel source)
        {
            return new Chat_Group()
            {
                Name = source.groupname,
                Photo = source.avatar,
                CreateTime = DateTime.Now
            };
        }

        public static List<FriendGroupViewModel> ToViewModel(this List<Chat_FriendGroup> source)
        {
            List<FriendGroupViewModel> result = new List<FriendGroupViewModel>();
            foreach(var item in source)
            {
                result.Add(item.ToViewModel());
            }
            return result;
        }

        public static UserViewModel ToViewModel(this User source)
        {
            return new UserViewModel()
            {
                id = source.AccountId,
                username = source.UserName,
            };
        }

    }
}
