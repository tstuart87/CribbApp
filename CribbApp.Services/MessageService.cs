using CribbApp.Data;
using CribbApp.Models.MessageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public MessageService()
        {
            // Empty Constructor
        }

        //Create

        public bool CreateMessage(MessageCreate message) //This needs changed to something that will send the ReceiverHouseId and SenderHouseId in from the Body.
        {
            HouseService houseService = new HouseService();

            int senderHouseId;

            using (var ctx = new ApplicationDbContext())
            {
                senderHouseId = houseService.GetHouseIdByOwnerId(_userId);
            }

                var entity =
                    new Message()
                    {
                        OwnerId = _userId,
                        SenderHouseId = senderHouseId,
                        ReceiverHouseId = message.ReceiverHouseId,
                        MessageContent = message.MessageContent,
                        DateCreated = DateTimeOffset.Now,
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.OwnerId == _userId) // This needs to get this by matching up the HouseId not OwnerId. No direct messaging. Just House > House.
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    MessageId = e.MessageId,
                                    OwnerId = e.OwnerId,
                                    SenderHouseId = e.SenderHouseId,
                                    ReceiverHouseId = e.ReceiverHouseId,
                                    MessageContent = e.MessageContent,
                                    DateCreated = e.DateCreated,
                                    //Replies = e.Replies,
                                    //Likes = e.Likes,
                                }
                        );

                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Messages.Single(h => h.MessageId == messageId && h.OwnerId == _userId);
                return new MessageDetail
                {
                    MessageId = entity.MessageId,
                    OwnerId = entity.OwnerId,
                    SenderHouseId = entity.SenderHouseId,
                    ReceiverHouseId = entity.ReceiverHouseId,
                    MessageContent = entity.MessageContent,
                    DateCreated = entity.DateCreated,
                    //Replies = entity.Replies,
                    //Likes = entity.Likes,
                };
            }
        }

        //Update

        public bool UpdateMessage(MessageEdit message)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Messages.Single(h => h.MessageId == message.MessageId && h.OwnerId == _userId);

                entity.MessageId = message.MessageId;
                entity.MessageContent = message.MessageContent;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete

        public bool DeleteMessage(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Messages.Single(h => h.MessageId == messageId && h.OwnerId == _userId);

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
