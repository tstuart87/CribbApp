using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public Guid OwnerId { get; set; }
        public int SenderHouseId { get; set; }
        public string MessageContent { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public int ReceiverHouseId { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
