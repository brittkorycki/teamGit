using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SocialMedia.Models
{
    public class LikeCreate
    {
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
        public Post LikedUser { get; set; }
    }
}
