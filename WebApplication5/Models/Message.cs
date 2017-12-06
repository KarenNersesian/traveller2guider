using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Message
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        public int ConversationID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        [ForeignKey("ConversationID"), Column(Order = 1)]
        public virtual Conversation Conversation { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}