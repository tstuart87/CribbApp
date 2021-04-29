using CribbApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Models.MessageModels
{
    public class MessageDetail
    {
        public int MessageId { get; set; }
        public Guid OwnerId { get; set; }
        public int SenderHouseId { get; set; }
        public int ReceiverHouseId { get; set; }
        public string MessageContent { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
