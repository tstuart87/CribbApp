using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class MessageReply
    {
        [Key]
        public int MessageReplyId { get; set; }
        //[ForeignKey("Message")]
        //public int MessageId { get; set; }

        //[ForeignKey("Reply")]
        //public int ReplyId { get; set; }
    }
}
