using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    
        public class Comment
        {
            [Key]
            public int CommentID { get; set; }
            public int ParentCommentID { get; set; }
            [Required]
            public string Text { get; set; }
            public User Author { get; set; }
            public Post CommentPost { get; set; }

        }
   
}
