﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate : CommentCreate
    {

        //[Required]
        //    [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        //    [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        //    public new string Text { get; set; }
        //    public new User Author { get; set; }
        public Comment ReplyComment { get; set; }

    }
}