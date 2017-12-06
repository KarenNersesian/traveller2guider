using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Conversation
    {
        [Key]
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }

        public DateTime ConversationCreateDate { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}