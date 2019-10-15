using System;
using System.Collections.Generic;
using System.Text;

namespace orkut2x.model
{
    class User
    {
        public string user { get; set; }
        public string uuid { get; set; }
        public string pic { get; set; }

        public User() { }
        public User (string username, string uuid, string pic) {
            this.user = username;
            this.uuid = uuid;
            this.pic = pic;
        }

    }
}
