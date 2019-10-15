using System;
using System.Collections.Generic;
using System.Text;

namespace orkut2x.model
{
    class Friend
    {
        public string userImgUrl { get; set; }
        public string shareImgUrl { get; set; }
        public string extrafld { get; set; }

        public Friend(string extra) {
            userImgUrl = "user.png";
            shareImgUrl = "share.png";
            extrafld = extra;
        }
    }
}
