using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CribbApp.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public Guid OwnerId { get; set; }
        public string ReplyContent { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey("Messages")]
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }
    }
}
