using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyList : CommentList
    {
        [Key]
        public int ReplyId { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
