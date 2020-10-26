using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyEdit : CommentEdit
    {
        public Comment ReplyComment { get; set; }
    }
}
