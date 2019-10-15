using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace orkut2x.model
{
    class Post {
        
        public Post(string username, string userUuid, string text, string image, bool postVisibility) {
            this.author = username;
            this.publisher = username;
            this.authorUuid = userUuid;
            this.publisherUuid = userUuid;
            this.image = image;
            this.text = text;
            this.isPublic = postVisibility;
        }
        public string pic { get; set; }
        public string uuid { get;  set; }
        public string author { get;  set; }
        public string publisher { get;  set; }
        public string authorUuid { get;  set; }
        public string publisherUuid { get;  set; }
        public string image { get;  set; }
        public string text { get;  set; }
        public bool isPublic { get;  set; }
        public int timestamp { get;  set; }

        public bool isShared { get; set; }
    }
}
